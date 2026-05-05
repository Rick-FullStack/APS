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
                _ = HandleClientAsync(client, stoppingToken);
            }
            catch { }
        }
    }

    private async Task HandleClientAsync(TcpClient client, CancellationToken token)
    {
        try
        {
            var stream = client.GetStream();
            var buffer = new byte[4096];

            while (client.Connected && !token.IsCancellationRequested)
            {
                int bytesRead = await stream.ReadAsync(buffer, token);
                if (bytesRead == 0) break;

                string json = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                if (!string.IsNullOrEmpty(json))
                {
                    await ProcessMessage(json);
                }
            }
        }
        catch { }
        finally
        {
            _clients.Remove(client);
            client.Close();
        }
    }

    private async Task ProcessMessage(string json)
    {
        try
        {
            using JsonDocument doc = JsonDocument.Parse(json);
            string? type = doc.RootElement.TryGetProperty("Type", out var t) ? t.GetString() : null;

            await _hub.Clients.All.SendAsync("ReceiveMessage", json); // fallback

            if (type == "DATA")
            {
                var payload = doc.RootElement.GetProperty("Payload");
                var data = JsonSerializer.Deserialize<EnvironmentalData>(payload.GetRawText());
                if (data != null)
                {
                    await _hub.Clients.All.SendAsync("ReceiveEnvironmentalData", data);
                }
            }
            else if (type == "ALERT")
            {
                var msg = "🚨 ALERTA CRÍTICO RECEBIDO!";
                await _hub.Clients.All.SendAsync("ReceiveAlert", msg);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar mensagem");
        }
    }
}