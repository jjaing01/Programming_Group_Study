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

    public async Task StartAsync(int port)
    {
        Console.WriteLine("STUN Server is starting");
        _signalListener = new TcpListener(IPAddress.Any, port);
        _signalListener.Start();
        Console.WriteLine($"Signal Server is running on port {port}");

        // PeerConnection 초기화
        await InitializePeerConnection();

        // 클라이언트 처리 시작
        await HandleSignalClientsAsync();
    }

    private async Task InitializePeerConnection()
    {
        // 1. PeerConnection 생성
        _peerConnection = new PeerConnection();

        // 2. ICE 후보가 준비되었을 때 호출되는 이벤트
        _peerConnection.IceCandidateReadytoSend += (candidate) =>
        {
            Console.WriteLine($"ICE Candidate: {candidate.ToString()}");
            SendIceCandidateToPeer(candidate);
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
        _peerConnection.LocalSdpReadytoSend += (sdp) =>
        {
            Console.WriteLine($"Local SDP: {sdp}");
            SendOfferToPeer(sdp); // Offer를 신호 서버를 통해 전달
        };

        // 5. PeerConnectionConfiguration 설정
        var peerConnectionConfig = new PeerConnectionConfiguration
        {
            IceServers = new List<IceServer>
            {
                new IceServer
                {
                    Urls = new List<string> { "stun:127.0.0.1:3478" } // 로컬 STUN 서버 주소
                    // Urls = new List<string> { "stun:stun.l.google.com:19302" } // StunServer에서 고정적으로 사용하는 포트 번호
                }
            }
        };

        // 6. Configuration 설정
        await _peerConnection.InitializeAsync(peerConnectionConfig);

        // 7. offer 생성
        bool offerCreated = _peerConnection.CreateOffer();
        if (offerCreated)
        {
            Console.WriteLine("Success to create offer.");
        }
        else
        {
            Console.WriteLine("Failed to create offer.");
        }
    }

    private async Task HandleSignalClientsAsync()
    {
        while (true)
        {
            if(_signalListener is not null)
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
                    var candidate = new IceCandidate();
                    _peerConnection?.AddIceCandidate(candidate);
                    Console.WriteLine($"Added ICE Candidate: {candidate}");
                }
                else if (message.StartsWith("OFFER:"))
                {
                    var offerSdp = message.Substring(6);
                    var remoteDescription = new SdpMessage
                    {
                        Content = offerSdp,
                        // Type = SdpType.Offer
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

    private static async Task SendIceCandidateToPeer(IceCandidate candidate)
    {
        try
        {
            // ICE 후보를 문자열로 변환 (보통 candidate.ToString() 메서드 사용 가능)
            string candidateString = candidate?.ToString() ?? "null";

            // 서버에 연결된 클라이언트에게 ICE 후보 전송 (TCP, WebSocket 등으로 전송)
            using (TcpClient client = new TcpClient("peerAddress", 12345)) // 상대 피어의 IP와 포트로 연결
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
            // Offer SDP 메시지를 문자열로 변환
            string offerSdpString = offerSdp.Content ?? "null";

            // 상대 피어에게 Offer 전송 (TCP, WebSocket 등으로 전송)
            // 테스트 클라 작성해서 접속 시도 하거나 유효한 포트 찾아야 함
            using (TcpClient client = new TcpClient("peerAddress", 3478)) // 상대 피어의 IP와 포트로 연결 // 실제 포트로 연결해야 함 아니면 socket 에러 나옴
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
        _signalListener?.Stop();
        _peerConnection?.Close();
        Console.WriteLine("STUN Server is shutting down...");
    }
}
