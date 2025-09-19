using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class TcpChatServer
{
    private TcpListener _listener;
    private List<TcpClient> _clients = new List<TcpClient>();
    private Dictionary<TcpClient, string> _clientNames = new Dictionary<TcpClient, string>();

    public async Task Start(int port)
    {
        _listener = new TcpListener(IPAddress.Any, port);
        _listener.Start();
        Console.WriteLine($"[SERVER] Сервер запущено на порту {port}");

        while (true)
        {
            var client = await _listener.AcceptTcpClientAsync();
            _clients.Add(client);
            Console.WriteLine("[SERVER] Новий клієнт підключився");

            // Асинхронно обробляємо цього клієнта
            HandleClientAsync(client);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        var stream = client.GetStream();

        // Першим повідомленням клієнт надсилає свій нік
        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        string name = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
        _clientNames[client] = name;

        Console.WriteLine($"[SERVER] Клієнт підключився: {name}");
        Broadcast($"{name} приєднався до чату", client);

        try
        {
            while (true)
            {
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) break; // Клієнт відключився

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                // Якщо /exit — клієнт виходить
                if (message == "/exit")
                {
                    Console.WriteLine($"[SERVER] {name} вийшов з чату");
                    _clients.Remove(client);
                    _clientNames.Remove(client);
                    Broadcast($"{name} вийшов з чату", client);
                    client.Close();
                    break;
                }

                Console.WriteLine($"[MESSAGE] {name}: {message}");
                Broadcast($"{name}: {message}", client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }
    }

    private void Broadcast(string message, TcpClient sender)
    {
        byte[] data = Encoding.UTF8.GetBytes(message + "\n");
        foreach (var client in _clients)
        {
            if (client == sender) continue; // не надсилаємо назад відправнику
            try
            {
                client.GetStream().WriteAsync(data, 0, data.Length);
            }
            catch { /* ігноруємо помилки */ }
        }
    }
}

class Program
{
    static async Task Main()
    {
        var server = new TcpChatServer();
        await server.Start(5000); // Порт можна змінити
    }
}
