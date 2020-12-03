using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTimer : MonoBehaviour
{
    public float startTime = 1.0f;
    
    public float fireRate;
    private float _offTimer;

    private float _onTimer;
    private bool _isOn = false;
    
    private ParticleSystem _fireParticle;
    private BoxCollider _fireBoxCol;

    private void Awake()
    {
        _fireParticle = gameObject.GetComponentInChildren<ParticleSystem>();
        _fireBoxCol = gameObject.GetComponentInChildren<BoxCollider>();
        _offTimer = fireRate+2.0f;
        _onTimer = fireRate;
   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (startTime < 0)
        {
            if (!_isOn)
            {
                _offTimer -= Time.deltaTime;
                if (_offTimer < 0)
                {
                    _offTimer = fireRate+2.0f;
                    _fireParticle.Play();
                    _fireBoxCol.enabled = true;
                    _isOn = true;
                }
            }
            else if (_isOn)
            {
                _onTimer -= Time.deltaTime;
                if (_onTimer < 0)
                {
                    _onTimer = fireRate;
                    _fireParticle.Stop();
                    _fireBoxCol.enabled = false;
                    _isOn = false;
                }
            }
        }
        else
        {
            startTime -= Time.deltaTime;
        }
    }
}
