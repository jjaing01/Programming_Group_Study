namespace CoreServer.Main;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.MixedReality.WebRTC;
public class StunServer
{
    private PeerConnection? _peerConnection;
    private DataChannel? _dataChannel;

    public StunServer()
    {
        InitializePeerConnection().GetAwaiter().GetResult();
        Console.WriteLine("StunServer Initialized!");
    }

    private async Task InitializePeerConnection()
    {
        // 1. PeerConnection 생성
        _peerConnection = new PeerConnection();
        

        // 2. ICE 후보가 준비되었을 때 호출되는 이벤트
        _peerConnection.IceCandidateReadytoSend += (candidate) =>
        {
            Console.WriteLine($"ICE Candidate: {candidate.ToString()}");

            // Todo: ICE 후보를 신호 서버를 통해 다른 피어에게 전달하는 로직을 추가 필요
        };

        // 3. 데이터 채널 추가 및 이벤트 설정
        _peerConnection.DataChannelAdded += (dataChannel) =>
        {
            _dataChannel = dataChannel;
            _dataChannel.MessageReceived += (message) =>
            {
                Console.WriteLine("Received message: " + message);
            };

            // Todo : Open/Close 이벤트 확인 필요
        };

        // 4. PeerConnectionConfiguration 설정
        var peerConnectionConfig = new PeerConnectionConfiguration
        {
            IceServers = new List<IceServer>
            {
                new IceServer
                {
                    Urls = new List<string> { "stun:stun.l.google.com:19302" } // StunServer에서 고정적으로 사용하는 포트 번호
                }
            }
        };

        // 5. Configuration 설정
        await _peerConnection.InitializeAsync(peerConnectionConfig);
        return;

        // offer, answer 세팅 필요

        // 6. Offer 생성
        //string offerSdp;
        bool offerCreated = _peerConnection.CreateOffer();
        if (offerCreated)
        {
            var localDescription = new SdpMessage
            {
                //Sdp = offerSdp,
                //Type = SdpType.Offer
            };

            await _peerConnection.SetRemoteDescriptionAsync(localDescription);
            Console.WriteLine($"Created Offer: {""}");

            //// 신호 서버를 통해 원격 피어의 Answer를 수신
            //string remoteAnswerSdp = await ReceiveRemoteAnswerFromSignalServer();


            //var remoteDescription = new SdpMessage
            //{
            //    // Sdp = remoteAnswerSdp,
            //    // Type = SdpType.Answer
            //};

            //// 원격 피어의 Answer를 설정
            //await _peerConnection.SetRemoteDescriptionAsync(remoteDescription);
        }
        else
        {
            Console.WriteLine("Failed to create offer.");
        }
    }

    public void Stop()
    {
        _peerConnection?.Dispose();
        Console.WriteLine("StunServer stopped.");
    }

    //public async Task SetRemoteAnswerAsync(string remoteAnswerSdp)
    //{
    //    var remoteDescription = new SdpMessage
    //    {
    //        //Sdp = remoteAnswerSdp,
    //        //Type = SdpType.Answer
    //    };

    //    await _peerConnection.SetRemoteDescriptionAsync(remoteDescription);
    //}
}