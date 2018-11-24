using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetComm : MonoBehaviour {

    public bool isText;
    public bool isImage;

    private TextMesh text;
    private Material material;

    // Use this for initialization
    void Start ()
    {
        if (isText)
        {
            text = GetComponent<TextMesh>();
            if (text != null)
            {
                StartCoroutine(GetText());
            };
        }

        if (isImage)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                material = renderer.material;
                StartCoroutine(GetImage());
            }
        }
    }

    /// <summary>
    /// Get Text from HTTP GET METHOD
    /// (before start, local server must be started)
    /// ex. python server.py
    /// </summary>
    /// <returns></returns>
    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/get_text.txt");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            // 結果をテキストとして表示します
            text.text = (www.downloadHandler.text);

            //  または、結果をバイナリデータとして取得します
            //           byte[] results = www.downloadHandler.data;
        }
    }

    /// <summary>
    /// Get Image from HTTP GET METHOD
    /// (before start, local server must be started)
    /// ex. python server.py
    /// </summary>
    /// <returns></returns>
    IEnumerator GetImage()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://localhost:8000/dog.jpg");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            material.mainTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}
