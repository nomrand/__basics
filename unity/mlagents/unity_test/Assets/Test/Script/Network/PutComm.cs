using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PutComm : MonoBehaviour {

    public Camera targetCamera;

	// Use this for initialization
	void Start () {
        var camUtil = targetCamera.GetComponent<CameraUtil>();
        StartCoroutine(PutData(camUtil.CamCapture()));
    }

    /// <summary>
    /// Save Raw Data by HTTP PUT METHOD
    /// (before start, local server must be started)
    /// ex. python server.py
    /// </summary>
    /// <returns></returns>
    IEnumerator PutData(byte[] bytes)
    {
        UnityWebRequest www = UnityWebRequest.Put("http://localhost:8000/", bytes);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
        }
    }
}
