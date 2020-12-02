using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{
    private bool isTouched = false;

    private bool isTouching = false;

    private bool isTouchable = false;
    // Start is called before the first frame update
    public GameObject[] StopObjs;
    public Transform player;
    
    // Update is called once per frame
    void Update()
    {
        if (isTouched && !isTouching)
        {
            foreach (var obj in StopObjs)
            {
                Animation[] anims = obj.GetComponentsInChildren<Animation>();

                foreach (var anim in anims)
                {

                    anim.clip.SampleAnimation(anim.gameObject, 0);
                    Debug.Log("됨");
                    anim.Stop();

                }
            }

            isTouching = true;
        }

        if (!isTouched && isTouching)
        {
            
            foreach (var obj in StopObjs)
            {
                Animation[] anims = obj.GetComponentsInChildren<Animation>();

                foreach (var anim in anims)
                {
                    anim.Play();
                }

            }

            isTouching = false;
        }

        isInRange();
    }

    private void isInRange()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (dist < 2.5f)
        {
            isTouchable = true;
        }
        else
        {
            isTouchable = false;
        }
  
    }

    public bool GetTouchable()
    {
        return isTouchable;
    }
    
    public void SetIsTouched()
    {
        isTouched = !isTouched;
    }
}
