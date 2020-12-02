using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Slider HungryBar;

    private void Update()
    {
        HungryBar.value -= 0.1f * Time.deltaTime;
        
        if (HungryBar.value <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
