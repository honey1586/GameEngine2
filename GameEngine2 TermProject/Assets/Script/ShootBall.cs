using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float torqueForce = 50;
    // Start is called before the first frame update

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 1500;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _rigidbody.AddTorque(transform.forward*torqueForce,ForceMode.Impulse);
        }
    }
}
