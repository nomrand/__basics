using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostComm : MonoBehaviour {

    public string text;

    // Use this for initialization
    void Start ()
    {
        if (text != null)
        {
            // Post
            StartCoroutine(PostData(text));

        }
    }
    
    /// <summary>
    /// Save String Data by HTTP POST METHOD
    /// (before start, local server must be started)
    /// ex. python server.py
    /// </summary>
    /// <returns></returns>
    IEnumerator PostData(string str)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        if (str != null)
        {
            formData.Add(new MultipartFormDataSection("text=" + str));
        }
        formData.Add(new MultipartFormDataSection("text1=aaa"));
        formData.Add(new MultipartFormDataSection("text2=bbb"));

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/", formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
