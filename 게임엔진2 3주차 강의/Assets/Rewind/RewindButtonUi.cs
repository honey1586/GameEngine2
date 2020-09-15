using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KPU.Manager;
public class RewindButtonUi : MonoBehaviour
{
    private Text _text;
    private bool _isRewinding;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }
    private void Start()
    {
        EventManager.On("rewind",OnRewind);
        EventManager.On("play",OnPlay);
    }

    private void OnRewind(object obj)
    {
        _text.text = "Play";
        _isRewinding = true;
    }
    private void OnPlay(object obj)
    {
        _text.text = "Rewind";
        _isRewinding = false;
    }
    public void Clicked()
    {
        var eventName = _isRewinding ? "play" : "rewind";
        EventManager.Emit(eventName, null);
    }
}
