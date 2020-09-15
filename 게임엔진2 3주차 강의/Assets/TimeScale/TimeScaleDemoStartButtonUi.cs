using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class TimeScaleDemoStartButtonUi : MonoBehaviour
{
   public void Clicked()
   {
       EventManager.Emit(eventName : "game_started", parameter : null);
   }
}
