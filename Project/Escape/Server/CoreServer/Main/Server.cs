namespace CoreServer.Main;
using System;
using System.Threading.Tasks;

public class Server
{
    public static Task Main(string[] args)
    {
        Console.WriteLine("Server Launch Start!!");

        // Todo 박용환 
        // 현재 테스트용으로 추후 작업 완료되면 별도로 관리 필요
        // STUN 서버 비동기로 시작, 유효한 포트 넘기도록
        var _stunServer = new StunServer();
        _stunServer.StartAsync(3478);

        // TODO 이동희
        // IP는 뭐 나중에 AWS 서버 생성 후 세팅
        // PORT는 팀원들과 논의
        string ipAddress = "127.0.0.1";
        int port = 13000;

        var echoServer = new EchoServer(ipAddress, port);
        echoServer.Listen();

        Console.WriteLine("Press ENTER to stop the server...");
        Console.ReadLine();

        echoServer.Stop();

        return Task.CompletedTask;
    }
}