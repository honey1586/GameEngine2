using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastTrap : MonoBehaviour
{
    public Rigidbody[] _fallingRock;
    // Start is called before the first frame update

    private float pushPower = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var rockRigid in _fallingRock)
            {
                rockRigid.isKinematic = false;
                other.gameObject.GetComponent<Rigidbody>()
                    .AddForce(gameObject.transform.forward * pushPower, ForceMode.Impulse);
            }
        }
    }
}
