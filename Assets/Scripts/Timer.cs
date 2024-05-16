using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameObject startLine;
    public float seconds = 0;
    public int minutes = 0;
    public string secondsString;
    public string minutesString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = minutesString + ":" + secondsString;
        seconds += Time.deltaTime;
        if ((int)seconds == 59) 
        {
            seconds = 0;
            minutes++;
        }
        secondsString = seconds.ToString("00");
        secondsString = seconds.ToString("00");
    }
    public void ResetTime()
    {
        seconds = 0;
        minutes = 0;
    }
}
