using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEditor.PackageManager;
using UnityEngine;

public class EchoServerConnection : MonoBehaviour
{
    private TcpClient client;
    private string serverIp = "127.0.0.1";
    private int serverPort = 13000;

    // Start is called before the first frame update
    void Start()
    {
        client = new TcpClient(serverIp, serverPort);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (client is not null)
            {
                Console.WriteLine("Connected to server.");

                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine("나가려면 'exit' 입력.");

                    while (true)
                    {
                        var message = "Hi";
                        var request = Encoding.ASCII.GetBytes(message);
                        stream.Write(request, 0, request.Length);

                        var buffer = new byte[1024];
                        var bytesRead = stream.Read(buffer, 0, buffer.Length);

                        var response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"response: {response}");

                    }
                }
            }
            else
            {
                // client = new TcpClient(serverIp, serverPort);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }

        Console.WriteLine("Client disconnected.");
    }
}
