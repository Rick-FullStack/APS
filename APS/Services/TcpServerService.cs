using APS.Hubs;
using APS.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace APS.Services;

public class TcpServerService : BackgroundService
{
    private readonly ILogger<TcpServerService> _logger;
    private readonly IHubContext<EnvironmentalHub> _hub;
    private TcpListener? _listener;
    private readonly List<TcpClient> _clients = new();
    private const int Port = 5000;

    public TcpServerService(ILogger<TcpServerService> logger, IHubContext<EnvironmentalHub> hub)
    {
        _logger = logger;
        _hub = hub;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _listener = new TcpListener(IPAddress.Any, Port);
        _listener.Start();
        _logger.LogInformation("🚀 Servidor TCP iniciado na porta {Port}", Port);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var client = await _listener.AcceptTcpClientAsync(stoppingToken);
                _clients.Add(client);
                _ = Task.Run(() => HandleClientAsync(client, stoppingToken));
            }
            catch (Exception ex) when (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogError(ex, "Erro ao aceitar cliente");
            }
        }
    }

    private async Task HandleClientAsync(TcpClient client, CancellationToken token)
    {
        var endpoint = client.Client.RemoteEndPoint?.ToString() ?? "Desconhecido";
        _logger.LogInformation("✅ Cliente conectado: {Endpoint}", endpoint);

        try
        {
            var stream = client.GetStream();
            var buffer = new byte[8192];

            while (client.Connected && !token.IsCancellationRequested)
            {
                int bytesRead = await stream.ReadAsync(buffer, token);
                if (bytesRead == 0) break;

                string json = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                if (!string.IsNullOrEmpty(json))
                {
                    await ProcessMessageAsync(json);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Cliente desconectado: {Endpoint}", endpoint);
        }
        finally
        {
            _clients.Remove(client);
            client.Close();
        }
    }

    private async Task ProcessMessageAsync(string json)
    {
        try
        {
            using JsonDocument doc = JsonDocument.Parse(json);
            string? type = doc.RootElement.TryGetProperty("Type", out var prop) ? prop.GetString() : null;

            if (type == "DATA")
            {
                var data = JsonSerializer.Deserialize<EnvironmentalData>(doc.RootElement.GetProperty("Payload").GetRawText());
                if (data != null)
                    await _hub.Clients.All.SendAsync("ReceiveEnvironmentalData", data);
            }
            else if (type == "ALERT")
            {
                await _hub.Clients.All.SendAsync("ReceiveAlert", "🚨 ALERTA CRÍTICO RECEBIDO DO CAMPO!");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar mensagem JSON");
        }
    }
}