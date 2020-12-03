using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFireRate : MonoBehaviour
{
    public float startTime;
    public float fireRate;
    private FireTimer[] firetimer;
    // Start is called before the first frame update
    void Awake()
    {
        firetimer = gameObject.GetComponentsInChildren<FireTimer>();
        
        foreach (var timer in firetimer)
        {
            timer.startTime = startTime;
            timer.fireRate = fireRate;
        }
    }


}
