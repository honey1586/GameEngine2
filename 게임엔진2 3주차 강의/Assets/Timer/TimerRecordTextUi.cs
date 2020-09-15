using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using KPU.Manager;
using KPU;

public class TimerRecordTextUi : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        var text = string.Empty;
        foreach (var record in Timer.Instance.RecordTimes)
        {
            var timeSpan = new TimeSpan(days:0,hours:0,minutes:0,seconds:0,milliseconds:(int)(Timer.Instance.CurrentTime * 1000));
            text += $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}:{timeSpan.Milliseconds:000}"+Environment.NewLine;
        }

        _text.text = text;
    }
}
