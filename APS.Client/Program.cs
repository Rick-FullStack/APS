using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using APS.Shared;

namespace APS.Client;

class Program
{
    private static TcpClient? _client;
    private static NetworkStream? _stream;
    private static string? _industryName;

    static async Task Main(string[] args)
    {
        Console.Title = "Cliente - Monitoramento Rio Tietê";

        Console.Write("Nome da Indústria: ");
        _industryName = Console.ReadLine() ?? "Indústria Teste";

        await ConnectToServer();

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Indústria: {_industryName}");
            Console.WriteLine("==============================");
            Console.WriteLine("1 - Enviar Dados Ambientais");
            Console.WriteLine("2 - Enviar Relatório");
            Console.WriteLine("3 - Enviar Alerta Crítico");
            Console.WriteLine("0 - Sair");
            Console.Write("\nOpção: ");

            string? op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1": await SendEnvironmentalData(); break;
                case "2": await SendFileReport(); break;
                case "3": await SendCriticalAlert(); break;
                default: Console.WriteLine("Opção inválida!"); break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static async Task ConnectToServer()
    {
        _client = new TcpClient();
        await _client.ConnectAsync("127.0.0.1", 5000);
        _stream = _client.GetStream();
        Console.WriteLine("✅ Conectado ao servidor!");
    }

    private static async Task SendEnvironmentalData()
    {
        var data = new EnvironmentalData
        {
            IndustryName = _industryName ?? "Indústria Teste",
            PollutionLevel = Random.Shared.Next(30, 250),
            Ph = Math.Round(5.5 + Random.Shared.NextDouble() * 3, 2),
            Temperature = Random.Shared.Next(15, 35),
            DissolvedOxygen = Math.Round(4.0 + Random.Shared.NextDouble() * 4, 2),
            Status = Random.Shared.Next(100) < 20 ? "Alerta" : "Normal",
            Timestamp = DateTime.Now
        };

        await SendAsync("DATA", data);
        Console.WriteLine("✅ Dados enviados!");
    }

    private static async Task SendFileReport()
    {
        Console.Write("Observação do relatório: ");
        string? note = Console.ReadLine();

        var file = new FileUpload
        {
            IndustryName = _industryName ?? "",
            FileName = "relatorio_inspecao.pdf",
            Notes = note
        };

        await SendAsync("FILE", file);
        Console.WriteLine("✅ Relatório enviado!");
    }

    private static async Task SendCriticalAlert()
    {
        var alert = new { Message = "🚨 ALERTA CRÍTICO - POLUIÇÃO MUITO ALTA NO RIO TIETÊ!" };
        await SendAsync("ALERT", alert);
        Console.WriteLine("🚨 Alerta crítico enviado!");
    }

    private static async Task SendAsync(string type, object payload)
    {
        if (_stream == null || !_client!.Connected)
            await ConnectToServer();

        var envelope = new { Type = type, Payload = payload };
        string json = JsonSerializer.Serialize(envelope) + "\n";

        byte[] bytes = Encoding.UTF8.GetBytes(json);
        await _stream!.WriteAsync(bytes);
        await _stream.FlushAsync();
    }
}