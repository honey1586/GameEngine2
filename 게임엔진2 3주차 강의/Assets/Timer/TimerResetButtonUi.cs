using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;
public class TimerResetButtonUi : MonoBehaviour
{
        public void Clicked()
    {
        EventManager.Emit(eventName: "timer_reset" , parameter : null);
    }
}
