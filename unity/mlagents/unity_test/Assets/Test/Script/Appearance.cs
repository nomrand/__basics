using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour {

    [Header("Start Header Here")]
    public int someValue1;
    [Space]
    public int someValue2;
    [Space]
    [Space]
    public int someValue3;

    [HideInInspector]
    public int hiddenValue;

    [SerializeField]
    private int dispValue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
