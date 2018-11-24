using UnityEngine;
using System.Text;

using System.Net;
using UnityEngine.UI;
using System.IO;

public class HTTPSVComm : MonoBehaviour {

    /// <summary>
    /// URL Must Ended with /
    /// </summary>
    public string ServerAddress = "http://localhost:8765/";

    public Text outText;

    // Use this for initialization
    void Start () {
        StartServer();
    }

    /// <summary>
    /// サーバースタート
    /// </summary>
    async void StartServer()
    {
        /// httpListenerで待ち受け
        var httpListener = new HttpListener();
        httpListener.Prefixes.Add(ServerAddress);
        httpListener.Start();

        while (true)
        {
            /// 接続待機
            var listenerContext = await httpListener.GetContextAsync();

            // RECEIVED
            HttpListenerRequest request = listenerContext.Request;
            Debug.Log("HTTP Received:URL=" + request.Url);

            if (request.Url.ToString().Contains("/exe"))
            {
                Debug.Log("DO EXECUTE");
                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                outText.text = request.Url + documentContents;
            }


            /// httpレスポンスを返す
            listenerContext.Response.StatusCode = 200;
            listenerContext.Response.Close();
        }
    }
}
