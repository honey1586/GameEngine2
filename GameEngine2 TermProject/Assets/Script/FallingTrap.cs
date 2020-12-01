using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    public Rigidbody trapRigidBody;
    public float fallingSpeed = 50;
    private void OnTriggerEnter(Collider other)
    {
        trapRigidBody.isKinematic = false;
        trapRigidBody.AddForce(Vector3.down*fallingSpeed,ForceMode.Impulse);
    }
}
