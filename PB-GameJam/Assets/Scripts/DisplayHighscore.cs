using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TimeSpan timeSpan = TimeSpan.FromSeconds(Score.Instance.highScore());
        TimeSpan timeSpan = TimeSpan.FromSeconds(1.1f);
        gameObject.GetComponent<Text>().text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
    }
}
