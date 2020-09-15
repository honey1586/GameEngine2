using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using KPU.Manager;
using KPU;

public class TimerStartButtonUi : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }
    void Start()
    {
        EventManager.On(eventName: "timer_start",OnTimerStart);
        EventManager.On(eventName: "timer_stop",OnTimerStop);
        EventManager.On(eventName: "timer_reset",OnTimerReset);
    }

    private void OnTimerStart(object obj)
    {
        _text.text = "Stop";
    }
     private void OnTimerStop(object obj)
    {
        _text.text = "Resume";
    }
     private void OnTimerReset(object obj)
    {
        _text.text = "Start";
    }


    public void Clicked()
    {
        var eventName = Timer.Instance.Active ? "timer_stop" : "timer_start";
        EventManager.Emit(eventName , parameter : null);
    }
}
