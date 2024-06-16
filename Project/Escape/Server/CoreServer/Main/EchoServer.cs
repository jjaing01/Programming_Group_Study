namespace CoreServer.Main;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class EchoServer
{
    private TcpListener tcpListener;
    bool isRunning;

    // 지정된 IP 주소와 포트 번호로 TCP 리스너를 시작
    public EchoServer(string ipAddress, int port) 
    {
        tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
        tcpListener.Start();

        isRunning = true;

        Console.WriteLine("EchoServer Start!");
    }

    public void Listen()
    {
        while(isRunning)
        {
            Console.WriteLine("Listening");

            try
            {
                // 클라이언트 연결 대기 및 수락
                TcpClient newClient = tcpListener.AcceptTcpClient();
                Console.WriteLine("Client Connected");

                // TODO.이동희
                // 우선은 단순 테스트 에코 서버니까,,, 클라이언트마다 별도의 스레드로 처리하자
                // 흠.. 나중에 CoreServer에서 다수의 쓰레드를 만들고,
                // 그 쓰레드 내부에서 Task를 생성하여 스케줄링 하도록 변경해보도록 하는게 좋을듯?
                Thread clientThread = new Thread(() => Handler(newClient));
                clientThread.Start();

            }
            catch (Exception e)
            {
                // InvalidOperationException, SocketException 같은 것이 발생할 수 있으므로 Catch 문도 섞어보자
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }

    public void Stop()
    {
        isRunning = false;
        tcpListener.Stop();
        Console.WriteLine("Echo server stopped.");
    }

    // 동기식 Handler
    private void Handler(TcpClient client)
    {
        // 바이트 단위로 데이터를 읽고 쓸 수 있는 스트림 - 서버/클라 데이터 송수신에 필요함
        // GetStream 호출 시, 클라이언트가 연결된 소켓의 NetworkStream 를 반환함
        NetworkStream stream = client.GetStream();

        // StreamReader, StreamWriter 객체를 사용해서 더 간단하게 처리할 수도 있지만, 일단은 원시적인 방법으로..
        var buffer = new byte[1024];
        int bytesRead;
        try
        {
            // 클라 입력 전까지 블로킹이고, 0을 read하게 되면 클라 세션 끊김이라고 보면 됨.
            while((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                var request = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"request: {request}");

                var serverMessage = "EchoServer_" + request;
                var response = Encoding.ASCII.GetBytes(serverMessage);
                stream.Write(response, 0, response.Length);
                Console.WriteLine($"response: {serverMessage}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }
        finally
        {
            client.Close();
            Console.WriteLine("Client disconnected.");
        }
    }
}