using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{

    [SerializeField] private float defaultTime = 3599.99f;
    private TimeSpan timeSpan;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            timeSpan = TimeSpan.FromSeconds(Score.Instance.highScore());
        }
        catch
        {
            timeSpan = TimeSpan.FromSeconds(defaultTime);
        }
        gameObject.GetComponent<Text>().text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
    }
}
