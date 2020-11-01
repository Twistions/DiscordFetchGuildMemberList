using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static private ClientWebSocket ws = new ClientWebSocket();
        static void Main(string[] args)
        {
            ConnectServer().Wait();
            SendMessage(Encoding.UTF8.GetBytes(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "text.txt"))).Wait();
            _ = FetchUsers();
            Console.ReadLine();
        }

        static async Task ConnectServer()
        {
            ws.Options.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36");
            ws.Options.SetRequestHeader("Origin", "https://discord.com");
            ws.Options.SetRequestHeader("Accept-Language", "en-US,en;q=0.9,tr-TR;q=0.8,tr;q=0.7");
            await ws.ConnectAsync(new Uri("wss://gateway.discord.gg/?encoding=json&v=8"), CancellationToken.None);
            _ = Task.Run(() => ReceiveMessagesTask());
        }

        static async Task SendMessage(byte[] message)
        {
            ArraySegment<byte> bytes = new ArraySegment<byte>(message);
            await ws.SendAsync(bytes, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        static async Task FetchUsers()
        {
            try
            {
                foreach (var item in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "messages.txt"))
                {
                    await SendMessage(Encoding.UTF8.GetBytes(item));
                    await Task.Delay(2000);
                }
                //   await SendMessage(Encoding.UTF8.GetBytes(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "text1.txt")));

            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
            }
        }

        static async Task ReceiveMessagesTask()
        {
            while (true)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        while (true)
                        {
                            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[89120]);
                            var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
                            ms.Write(buffer.Array, buffer.Offset, result.Count);
                            if (result.EndOfMessage)
                            {
                                break;
                            }
                        }
                        Direct(ms.ToArray());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message + " " + e.StackTrace);
                }
            }
        }
        static int logCount = 0;
        static void Direct(byte[] message)
        {
            string mes = Encoding.UTF8.GetString(message);
            GatewayMessage m = JsonConvert.DeserializeObject<GatewayMessage>(mes);
            
            if (m.T == "GUILD_MEMBERS_CHUNK")
            {
                Console.WriteLine(m.T);
                Console.WriteLine(mes);
            }
            if (m.T == "GUILD_MEMBER_LIST_UPDATE")
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "log" + logCount + ".txt", mes);
                logCount++;
                Console.WriteLine(m.T);
                Console.WriteLine(mes);
            }
        }
    }

    class GatewayMessage
    {
        public string T { get; set; }
    }
}
