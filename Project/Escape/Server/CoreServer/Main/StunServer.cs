namespace CoreServer.Main;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.MixedReality.WebRTC;
using System.Net.Sockets;
using System.Net;
using System.Text;

public class StunServer
{
    private TcpListener? _signalListener;
    private PeerConnection? _peerConnection;
    private DataChannel? _dataChannel;

    bool isRunning;

    public StunServer(string ipAddress, int port)
    {
        Console.WriteLine("STUN Server is starting");
        _signalListener = new TcpListener(IPAddress.Any, port);
        _signalListener.Start();
        Console.WriteLine($"Signal Server is running on port {port}");

        isRunning = true;

        Console.WriteLine("StunServer Start!");

        StartAsync();
    }

    public async Task StartAsync()
    {
        // PeerConnection 초기화
        await InitializePeerConnection();

        // 클라이언트 처리 시작
        await HandleSignalClientsAsync();

        isRunning = true;
    }

    public void Listen()
    {
        while (isRunning)
        {
            Console.WriteLine("Listening");

            try
            {
                // 클라이언트 연결 대기 및 수락
                TcpClient newClient = _signalListener.AcceptTcpClient();
                Console.WriteLine("Client Connected");


                Thread clientThread = new Thread(() => HandleClientAsync(newClient));
                clientThread.Start();

            }
            catch (Exception e)
            {
                // InvalidOperationException, SocketException 같은 것이 발생할 수 있으므로 Catch 문도 섞어보자
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }

    private async Task InitializePeerConnection()
    {
        // 1. PeerConnection 생성
        _peerConnection = new PeerConnection();

        // 2. ICE 후보가 준비되었을 때 호출되는 이벤트
        _peerConnection.IceCandidateReadytoSend += async (candidate) =>
        {
            Console.WriteLine($"ICE Candidate: {candidate.ToString()}");
            await SendIceCandidateToPeer(candidate); // await 추가
        };

        // 3. 데이터 채널 추가 및 이벤트 설정
        _peerConnection.DataChannelAdded += (dataChannel) =>
        {
            _dataChannel = dataChannel;
            _dataChannel.MessageReceived += (message) =>
            {
                Console.WriteLine("Received message: " + message);
            };

            // Open/Close 이벤트 처리
            _dataChannel.StateChanged += () =>
            {
                Console.WriteLine($"Data channel state changed");
            };
        };

        // 4. LocalSdpReadytoSend 이벤트 설정
        _peerConnection.LocalSdpReadytoSend += async (sdp) =>
        {
            Console.WriteLine($"Local SDP: {sdp}");
            await SendOfferToPeer(sdp); // 클라이언트의 Offer를 수신 후 서버에서 Answer를 생성하도록 코드를 수정합니다.
        };

        // 5. PeerConnectionConfiguration 설정
        var peerConnectionConfig = new PeerConnectionConfiguration
        {
            IceServers = new List<IceServer>
        {
            new IceServer
            {
                Urls = new List<string> { "stun:127.0.0.1:13000" }
            }
        }
        };

        // 6. Configuration 설정
        await _peerConnection.InitializeAsync(peerConnectionConfig);
    }

    //private async Task InitializePeerConnection()
    //{
    //    // 1. PeerConnection 생성
    //    _peerConnection = new PeerConnection();

    //    // 2. ICE 후보가 준비되었을 때 호출되는 이벤트
    //    _peerConnection.IceCandidateReadytoSend += async (candidate) =>
    //    {
    //        Console.WriteLine($"ICE Candidate: {candidate.ToString()}");
    //        await SendIceCandidateToPeer(candidate); // await 추가
    //    };

    //    // 3. 데이터 채널 추가 및 이벤트 설정
    //    _peerConnection.DataChannelAdded += (dataChannel) =>
    //    {
    //        _dataChannel = dataChannel;
    //        _dataChannel.MessageReceived += (message) =>
    //        {
    //            Console.WriteLine("Received message: " + message);
    //        };

    //        // Open/Close 이벤트 처리
    //        _dataChannel.StateChanged += () =>
    //        {
    //            Console.WriteLine($"Data channel state changed");
    //        };
    //    };

    //    // 4. LocalSdpReadytoSend 이벤트 설정
    //    _peerConnection.LocalSdpReadytoSend += async (sdp) =>
    //    {
    //        Console.WriteLine($"Local SDP: {sdp}");
    //        await SendOfferToPeer(sdp); // await 추가
    //    };

    //    // 5. PeerConnectionConfiguration 설정
    //    var peerConnectionConfig = new PeerConnectionConfiguration
    //    {
    //        IceServers = new List<IceServer>
    //        {
    //            new IceServer
    //            {
    //                Urls = new List<string> { "stun:127.0.0.1:13000" }
    //            }
    //        }
    //    };

    //    // 6. Configuration 설정
    //    await _peerConnection.InitializeAsync(peerConnectionConfig);

    //    // 7. offer 생성
    //    bool offerCreated = _peerConnection.CreateOffer();
    //    Console.WriteLine(offerCreated ? "Success to create offer." : "Failed to create offer.");
    //}

    private async Task HandleSignalClientsAsync()
    {
        while (true)
        {
            if (_signalListener is not null)
            {
                var client = await _signalListener.AcceptTcpClientAsync();
                if (client is not null)
                {
                    Console.WriteLine("Client connected.");
                    _ = HandleClientAsync(client);
                }
            }
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        using (var stream = client.GetStream())
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received message from peer: {message}");

                if (message.StartsWith("ICE:"))
                {
                    var candidateInfo = message.Substring(4); // 메시지에서 후보 정보 추출.
                    var candidate = new IceCandidate
                    {
                        // 실제 후보 정보 설정 필요
                        Content = candidateInfo,
                        SdpMid = "Game", // 적절한 값으로 설정
                        SdpMlineIndex = 0   // 적절한 값으로 설정
                    };
                    _peerConnection?.AddIceCandidate(candidate);
                    Console.WriteLine($"Added ICE Candidate: {candidate}");
                }
                else if (message.StartsWith("OFFER:"))
                {
                    var offerSdp = message.Substring(6);
                    var remoteDescription = new SdpMessage
                    {
                        Content = offerSdp,
                        // Type = SdpType.Offer // 필요한 경우 추가
                    };

                    if (_peerConnection is not null)
                    {
                        await _peerConnection.SetRemoteDescriptionAsync(remoteDescription);
                        Console.WriteLine($"Set Remote Description: {offerSdp}");
                    }
                }
            }
        }

        client.Close();
        Console.WriteLine("Client disconnected.");
    }

    private async Task SendIceCandidateToPeer(IceCandidate candidate)
    {
        try
        {
            string candidateString = candidate?.ToString() ?? "null";

            // 상대 피어의 IP와 포트로 연결
            using (TcpClient client = new TcpClient("peerAddress", 12345))
            {
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes($"ICE:{candidateString}");
                await stream.WriteAsync(data, 0, data.Length);
                Console.WriteLine($"Sent ICE Candidate to peer: {candidateString}");
            }
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"Failed to send ICE Candidate. Socket error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send ICE Candidate. Error: {ex.Message}");
        }
    }

    private async Task SendOfferToPeer(SdpMessage offerSdp)
    {
        try
        {
            string offerSdpString = offerSdp.Content ?? "null";
            
            using (TcpClient client = new TcpClient("127.0.0.1", 13000)) // 실제 IP와 포트로 연결
            {
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes($"OFFER:{offerSdpString}");
                await stream.WriteAsync(data, 0, data.Length);
                Console.WriteLine($"Sent Offer to peer: {offerSdpString}");
            }
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"Failed to send Offer. Socket error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send Offer. Error: {ex.Message}");
        }
    }

    public void Stop()
    {
        try
        {
            _signalListener?.Stop();
            _peerConnection?.Close();
            Console.WriteLine("STUN Server is shutting down...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error shutting down server: {ex.Message}");
        }
    }
}