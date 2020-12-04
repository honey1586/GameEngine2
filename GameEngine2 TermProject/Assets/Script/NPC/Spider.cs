using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Spider : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent nav;

    //필요한 컴포넌트
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private BoxCollider boxCollider;

    [SerializeField] private AudioSource audio;
    
    private Vector3 SpiderStartPos;

    public bool isDead = false;
    public bool isHit = false;
    private bool isAttack = false;
    private bool SoundPlayed = false;
    private float timer;

    private float _playerDieTimer =2.0f;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();

        SpiderStartPos = transform.position;
    }

    void Update()
    {
        if (!isDead)
        {
            if (Vector3.Distance(target.position, transform.position) <= 15)
            {
                if (!SoundPlayed)
                {
                    audio.Play();
                    SoundPlayed = true;
                }

                TraceTarget();
            }

            if (Vector3.Distance(target.position, transform.position) > 15)
            {
                StopTrace();
                if (SoundPlayed)
                {
                   
                    SoundPlayed = false;
                }
            }

            if (Vector3.Distance(target.position, transform.position) <= 4.0f)
            {
                
               
                
                if (!isAttack)
                {
                    AttackTarget();
                }
                else
                {
                    if (_playerDieTimer < 0)
                    {
                        target.gameObject.GetComponent<PlayerMove>().PlayerDie();
                        _playerDieTimer = 2.0f;
                    }
                    else
                    {
                        _playerDieTimer -= Time.deltaTime;

                    }
                }
            }
        }

        if (isDead)
        {
            timer += Time.deltaTime;
            if (timer >= 2.0)
            {
                gameObject.SetActive(false);
            }
        }

    }

    private void TraceTarget()
    {
        // 플레이어와의 거리가 10보다 가까울 때 
        nav.Resume();
        transform.LookAt(target);
        anim.SetBool("Walking", true);
        nav.SetDestination(target.position);
        
    }

    private void StopTrace()
    {
        nav.SetDestination(SpiderStartPos);
        if (Vector3.Distance(SpiderStartPos , transform.position) <= 0.1f)
        {
            anim.SetBool("Walking", false);
            nav.Stop();
        }
    }

    private void AttackTarget()
    {
        isAttack = true;
        nav.Stop();
        anim.SetTrigger("Attack");
       
    }

    private void SpiderDead()
    {
        isDead = true;
        nav.Stop();
        rigid.velocity = Vector3.zero;
        anim.SetTrigger("Dead");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Grabable"))
        {
            ObjectGrab objGrab = other.gameObject.GetComponent<ObjectGrab>();
            if (!objGrab.isGrabed&&objGrab.isShoot)
            {
                isHit = true;
                SpiderDead();
            }
        }

        if (other.gameObject.CompareTag("Killable"))
        {
            SpiderDead();

        }
    }
}
