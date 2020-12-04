using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Slider HungryBar;
    private bool isRun = false;
    public PlayerMove player;
    private void Update()
    {
        if (!isRun)
        {
            HungryBar.value -= 0.6f * Time.deltaTime;
        }
        else
        {
            HungryBar.value -= 1.2f * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRun = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRun = false;
        }
        if (HungryBar.value <= 0)
        {
            gameObject.SetActive(false);
            player.PlayerDie();
        }
    }
}
