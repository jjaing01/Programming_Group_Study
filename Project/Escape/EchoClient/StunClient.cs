//using Microsoft.MixedReality.WebRTC;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using System.Collections.Generic;

//// Todo(박용환) : 테스트 용도 유니티에 이식 필요
//public class StunClient
//{
//    private TcpClient? client;
//    private NetworkStream? stream;
//    private PeerConnection? peerConnection;

//    public string stunServerAddress = "127.0.0.1";
//    public int stunServerPort = 13000;

//    // Main 메서드를 async로 변경
//    public static async Task Main(string[] args)
//    {
//        StunClient stunClient = new StunClient();
//        await stunClient.Start();  // Start 메서드 호출
//    }

//    // Start 메서드
//    public async Task Start()
//    {
//        await InitializePeerConnection();
//        await ConnectToStunServer();
//    }

//    // PeerConnection 초기화 및 Offer 생성
//    public async Task InitializePeerConnection()
//    {
//        peerConnection = new PeerConnection();

//        // SDP 오퍼 생성 이벤트 처리
//        peerConnection.LocalSdpReadytoSend += async (sdp) =>
//        {
//            Console.WriteLine($"Local SDP: {sdp.Content}");
//            await SendOfferToServer(sdp.Content);
//        };

//        // ICE 후보 생성 이벤트 처리
//        peerConnection.IceCandidateReadytoSend += (candidate) =>
//        {
//            Console.WriteLine($"ICE Candidate: {candidate.Content}");
//        };

//        // ICE 상태 변경 이벤트 처리
//        peerConnection.IceStateChanged += (state) =>
//        {
//            Console.WriteLine($"ICE State Changed: {state}");
//        };

//        // PeerConnection 설정
//        var config = new PeerConnectionConfiguration
//        {
//            IceServers = new List<IceServer>
//        {
//            new IceServer { Urls = new List<string> { "stun:127.0.0.1:13000" } }
//        }
//        };

//        await peerConnection.InitializeAsync(config);

//        // Offer 생성
//        try
//        {
//            bool offerCreated = peerConnection.CreateOffer();
//            Console.WriteLine(offerCreated ? "Offer created." : "Failed to create offer.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error creating offer: {ex.Message}");
//        }
//    }

//    // STUN 서버와 TCP 연결
//    public async Task ConnectToStunServer()
//    {
//        client = new TcpClient();
//        try
//        {
//            await client.ConnectAsync(stunServerAddress, stunServerPort);
//            Console.WriteLine("Connected to STUN server");
//            stream = client.GetStream();
//        }
//        catch (SocketException ex)
//        {
//            Console.WriteLine($"Failed to connect to STUN server: {ex.Message}");
//        }
//    }

//    // SDP Offer를 STUN 서버로 전송
//    public async Task SendOfferToServer(string offerSdp)
//    {
//        while (true)
//        {
//            if (client != null && client.Connected && stream != null)
//            {
//                string message = $"OFFER:{offerSdp}";
//                byte[] data = Encoding.UTF8.GetBytes(message);
//                try
//                {
//                    await stream.WriteAsync(data, 0, data.Length);
//                    Console.WriteLine("Success Sent Offer SDP to STUN server");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error sending Offer SDP: {ex.Message}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Fail Sent Offer SDP to STUN server: Client is null or not connected, or stream is null");
//            }
//        }
//    }

//    private void OnApplicationQuit()
//    {
//        if (client != null)
//        {
//            stream.Close();
//            client.Close();
//            Console.WriteLine("Disconnected from STUN server");
//        }
//    }
//}
