using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    public float throwForce = 10;
    public UserInterface ui;
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
                        objGrab.isGrabed = true;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        objGrab.objrigid.isKinematic = false;
                        objGrab.transform.parent = null;
                        objGrab.isGrabed = false;

                    }
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        objGrab.objrigid.isKinematic = false;
                        objGrab.isGrabed = false;
                        objGrab.transform.parent = null;
                        objGrab.isShoot = true;
                        objGrab.objrigid.AddForce(transform.forward*throwForce,ForceMode.Impulse);
                        
                    }
                }
            }
            else if (_hitInfo.transform.gameObject.CompareTag("Touchable"))
            {
                if (_hitInfo.transform.gameObject.GetComponent<TouchObject>().GetTouchable())
                {
                    TouchObject touchObj = _hitInfo.transform.gameObject.GetComponent<TouchObject>();
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Touch");
                        touchObj.SetIsTouched();
                    }
                }

            }
            else if (_hitInfo.transform.gameObject.CompareTag("Eatable"))
            {
                if (_hitInfo.transform.gameObject.GetComponent<Consumer>().GetIsTouchable())
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("Touch");
                        _hitInfo.transform.gameObject.GetComponent<Consumer>().Consume();
                        ui.HungryBar.value += 25f;

                        //여기에 배고픔 4분의1씩 차는거 구현하심됩니다.
                    }
                }
            }
            
        }
    }
}
