using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterSound : MonoBehaviour
{
    public AudioSource cutterSound;
    private void OnTriggerEnter(Collider other)
    {
        cutterSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        cutterSound.Stop();
    }
}
