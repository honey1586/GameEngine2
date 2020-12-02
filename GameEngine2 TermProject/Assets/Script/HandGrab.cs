using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    public float throwForce = 10;
    private RaycastHit _hitInfo;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        HandRayCast();
    }

    void HandRayCast()
    {
        //Debug.DrawRay(transform.position, transform.forward*5,Color.blue, 1f);
        if (Physics.Raycast(transform.position, transform.forward, out _hitInfo, 1))
        {
            if (_hitInfo.transform.gameObject.CompareTag("Grabable"))
            {
                if (_hitInfo.transform.gameObject.GetComponent<ObjectGrab>().GetIsGrabable())
                {
                    ObjectGrab objGrab = _hitInfo.transform.gameObject.GetComponent<ObjectGrab>();
                    if (Input.GetMouseButtonDown(0))
                    {
                      
                        objGrab.objrigid.isKinematic = true;
                        objGrab.transform.parent = transform;
                        
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        objGrab.objrigid.isKinematic = false;
                        objGrab.transform.parent = null;

                    }
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        objGrab.objrigid.isKinematic = false;
                        objGrab.transform.parent = null;
                        objGrab.objrigid.AddForce(transform.forward*throwForce,ForceMode.Impulse);
                    }
                }
            }
        }
    }
}
