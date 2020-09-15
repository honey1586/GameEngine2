using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU;
using KPU.Manager;

public class Timer : SingletonBehaviour<Timer>
{
    private float _time;
    private bool _active;
    private List<float> _recordTimes;

    public float CurrentTime => _time;
    public bool Active => _active;
    public List<float> RecordTimes => _recordTimes;

    private void Awake()
    {
        _recordTimes = new List<float>();
        _active = false;
    }

    void Start()
    {
        EventManager.On(eventName: "timer_start",OnTimerStart);
        EventManager.On(eventName: "timer_stop",OnTimerStop);
        EventManager.On(eventName: "timer_reset",OnTimerReset);
        EventManager.On(eventName: "timer_record",OnTimerRecord);
    }

    private void OnTimerStart(object obj)
    {
        _active = true;
    }
        private void OnTimerStop(object obj)
    {
        _active = false;
    }

    private void OnTimerReset(object obj)
    {
        RecordTimes.Clear();
        _active = false;
        _time = 0f;
    }

    private void OnTimerRecord(object obj)
    {
        if(_recordTimes.Count > 5)
            _recordTimes.RemoveAt(index:0);

        _recordTimes.Add(_time);
    }


    // Update is called once per frame
    void Update()
    {
        if(_active)
            _time += Time.deltaTime;
        
    }
}
