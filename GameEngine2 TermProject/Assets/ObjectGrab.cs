using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    private Rigidbody _rigid;

    public Transform player;

    public Transform playerHand;

    public float throwForce = 10;

    private bool isRanged = false;

    private bool isGrabed = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (dist < 2.5f)
        {
            isRanged = true;
        }
        else
        {
            isRanged = false;
        }


        if (isRanged && Input.GetMouseButtonDown(0))
        {
            _rigid.isKinematic = true;
            transform.parent = playerHand;
            isGrabed = true;
        }

        if (isGrabed)
        {
            if (Input.GetMouseButtonUp(0))
            {
                _rigid.isKinematic = false;
                transform.parent = null;
                isGrabed = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigid.isKinematic = false;
                transform.parent = null;
                _rigid.AddForce(playerHand.forward*throwForce,ForceMode.Impulse);
            }
        }
    }
}
