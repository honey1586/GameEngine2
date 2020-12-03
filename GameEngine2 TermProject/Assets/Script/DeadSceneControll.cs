using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadSceneControll : MonoBehaviour
{
    [SerializeField] private GameObject userInter;

    private float timer;

    private bool returnTitle = false;

    private float red = 255;
    private void Update()
    {
        timer += Time.deltaTime;
        if (red > 0)
        {
            red -= 1.0f;
        }

        GameObject.Find("PrevColor").GetComponent<Image>().color = new Color(red/255f, 0f, 0f);
        if (timer >= 3.0f)
        {
            returnTitle = true;
        }
        
        if (returnTitle)
        {
            gameObject.SetActive(false);

            SceneManager.LoadScene(0);
        }
    }
}
