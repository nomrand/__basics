using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour {

    private bool isStart = true;
    
    public void StartStop()
    {
        if (isStart)
        {
            isStart = false;
            Time.timeScale = 0.0f;
        }
        else
        {
            isStart = true;
            Time.timeScale = 1.0f;
        }
    }
}
