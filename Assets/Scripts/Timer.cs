using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI prevBest;
    public int prevBestInt;
    public GameObject startLine;
    public float seconds = 0;
    public int minutes = 0;
    public string secondsString;
    public string minutesString;
    public bool isGoing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoing)
        {
            timer.text = "time: " + minutesString + ":" + secondsString;
            seconds += Time.deltaTime;
            if ((int)seconds == 59)
            {
                seconds = 0;
                minutes++;
            }
            secondsString = seconds.ToString("00");
            secondsString = seconds.ToString("00");
        }
    }
    public void ResetTime()
    {
        if ((minutes * 60) + seconds >= prevBestInt )
        {
            prevBestInt = (minutes * 60) + Mathf.RoundToInt(seconds);
            prevBest.text = "best: " + minutesString + ":" + secondsString;
        }
        seconds = 0;
        minutes = 0;
    }
}
