using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEditor.PackageManager;
using UnityEngine;

public class EchoServerConnection : MonoBehaviour
{
    public TcpClient client;

    // Start is called before the first frame update
    void Start()
    {
        string serverIp = "127.0.0.1";
        int serverPort = 13000;

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

                        //var message = Console.ReadLine();
                        //if (message.ToLower() == "exit")
                        //{
                        //    break;
                        //}

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
