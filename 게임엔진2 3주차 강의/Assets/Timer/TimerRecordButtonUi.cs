using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class TimerRecordButtonUi : MonoBehaviour
{
        public void Clicked()
    {
        EventManager.Emit(eventName: "timer_record" , parameter : null);
    }
}
