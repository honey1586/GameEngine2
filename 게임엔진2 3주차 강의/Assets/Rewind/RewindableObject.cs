using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class RewindableObject : MonoBehaviour
{
    private bool _isRecordOn;
    private IList<RewindRecord> _rewindRecords;
    private Rigidbody _rigidbody;
    private Coroutine _rewindRoutine;

    private void Awake()
    {
        _isRecordOn = true;
        _rewindRecords = new List<RewindRecord>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        EventManager.On("rewind",OnRewind);
        EventManager.On("play",OnPlay);
    }

    private void OnPlay(object obj)
    {
        if(_rewindRoutine != null) 
            StopCoroutine(_rewindRoutine);

        _isRecordOn = true;
        _rigidbody.isKinematic = false;
        _rewindRecords.Clear();
    }

    private void OnRewind(object obj)
    {
        _isRecordOn = false;
        _rewindRoutine = StartCoroutine(RewindRoutine());
    }

    private IEnumerator RewindRoutine()
    {
        foreach(var record in _rewindRecords)
        {
            _rigidbody.isKinematic = true;     // 물리 시뮬레이션 x
            transform.position = record.Position;
            transform.rotation = record.Rotation;
            _rigidbody.velocity = record.Velocity;
            _rigidbody.angularVelocity = record.AngularVelocity;

            yield return new WaitForFixedUpdate();
        }
    }

    private void FixedUpdate()
    {
        if(_isRecordOn){
            _rewindRecords.Insert(index:0,item:new RewindRecord
            {
                Position = transform.position,
                Rotation = transform.rotation,
                Velocity = _rigidbody.velocity,
                AngularVelocity = _rigidbody.angularVelocity
            });
        }
    }

}
