using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class WebSocketCLComm : MonoBehaviour {

    public string WebSocketServer = "ws://localhost:8765";

    // public ClientWebSocket clientWebSocket;

    public Text outText;

    void Start()
    {

    }

    public async void DoWsSend(string str)
    {
        ClientWebSocket clientWebSocket = new ClientWebSocket();

        //        clientWebSocket.Options.AddSubProtocol("Tls");

        try
        {
            Uri uri = new Uri(WebSocketServer);
            await clientWebSocket.ConnectAsync(uri, CancellationToken.None);
            if (clientWebSocket.State == WebSocketState.Open)
            {
                Debug.Log("[WS][connect]:" + "Connected");

                // Send
                ArraySegment<byte> bytesToSend = new ArraySegment<byte>(
                    Encoding.UTF8.GetBytes(str)
                );
                await clientWebSocket.SendAsync(
                    bytesToSend,
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None
                );

                // Get Response
                ArraySegment<byte> bytesReceived = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await clientWebSocket.ReceiveAsync(
                    bytesReceived,
                    CancellationToken.None
                );

                // Out
                outText.text = (Encoding.UTF8.GetString(bytesReceived.Array, 0, result.Count));
            }
        }
        catch (Exception e)
        {
            Debug.LogError("[WS][exception]:" + e.Message);
            if (e.InnerException != null)
            {
                Debug.LogError("[WS][inner exception]:" + e.InnerException.Message);
            }
        }
        Debug.Log("[WS]:" + "Finnished");
    }
}
