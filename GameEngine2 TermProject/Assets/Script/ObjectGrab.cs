using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    public Rigidbody objrigid;

    public Transform player;
    
    

    private bool IsGrabable = false;

    public bool isGrabed = false;

    public bool isShoot = false;

    private float shootTimer = 5.0f;
    // Start is called before the first frame update
    void Awake()
    {
        objrigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        isInRange();

        if (isShoot)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0)
            {
                shootTimer = 5.0f;
                isShoot = false;
            }
        }
    }

    public void isInRange()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (dist < 2.5f)
        {
            IsGrabable = true;
        }
        else
        {
            IsGrabable = false;
        }
  
    }

  
    public bool GetIsGrabable()
    {
        return IsGrabable;
    }
}
