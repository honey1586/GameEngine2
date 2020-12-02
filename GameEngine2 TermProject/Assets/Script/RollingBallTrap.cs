using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RollingBallTrap : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    public GameObject rollingBall;
    public float rollingSpeed;
    private bool isRolling = false;
    private float _rollTimer = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = rollingBall.GetComponent<Rigidbody>();
        ballRigidbody.maxAngularVelocity = 1500;

    }

    private void OnTriggerEnter(Collider other)
    {
        isRolling = true;
    }

    private void Update()
    {
        if (isRolling)
        {
            _rollTimer -= Time.deltaTime;
        }

        if (_rollTimer < 0)
        {
            
            ballRigidbody.AddTorque(rollingBall.transform.forward*rollingSpeed,ForceMode.Impulse);
            Debug.Log("rolling");
            isRolling = false;
            _rollTimer = 3.0f;
        }
    }
}
