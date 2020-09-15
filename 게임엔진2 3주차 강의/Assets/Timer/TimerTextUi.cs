using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerTextUi : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        var timeSpan = new TimeSpan(days:0,hours:0,minutes:0,seconds:0,milliseconds:(int)(Timer.Instance.CurrentTime * 1000));
        _text.text = $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}:{timeSpan.Milliseconds:000}";
    }
}
