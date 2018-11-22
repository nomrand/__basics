using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logging : MonoBehaviour {

    public GameObject other;

	// Use this for initialization
	void Start () {
        Debug.Log("LOG!");
        Debug.LogFormat("LOG! (normal){0}", 1 + 1);
        Debug.Log($"LOG! (zero padding3){1 + 1:000}");

        // WARNING
        Debug.LogWarning("WAR!");
        string aaa = "a";
        Debug.LogWarningFormat("WAR! (space padding5){0, 5}x", aaa);
        Debug.LogWarning($"WAR! (space padding5){aaa, -5}x");

        // ERROR
        Debug.LogError("ERR!");
        Debug.LogError(string.Format("ERR! (bracket){{{0}}}", 0.25));
        Debug.LogError($"ERR! (bracket){{{0.25}}}");

        // Object specific
        Debug.Log("message for this object", this);
        Debug.Log("message for other object", other);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
