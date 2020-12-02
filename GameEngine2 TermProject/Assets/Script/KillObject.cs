using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")&&!other.gameObject.CompareTag("SafeZone"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
