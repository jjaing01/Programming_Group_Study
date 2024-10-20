using System.Net.Sockets;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class EchoClient
{
    static void Main(string[] args)
    {
        string serverIp = "127.0.0.1";
        int serverPort = 13000;

        try
        {
            using (TcpClient client = new TcpClient(serverIp, serverPort))
            {
                Console.WriteLine("Connected to server.");

                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine("나가려면 'exit' 입력.");

                    while (true)
                    {
                        var message = Console.ReadLine();
                        if (message.ToLower() == "exit")
                        {
                            break;
                        }

                        var request = Encoding.ASCII.GetBytes(message);
                        stream.Write(request, 0, request.Length);

                        var buffer = new byte[1024];
                        var bytesRead = stream.Read(buffer, 0, buffer.Length);

                        var response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"response: {response}");
                      
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }

        Console.WriteLine("Client disconnected.");
    }
}
