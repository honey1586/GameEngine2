using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour
{
    private float timer;
    private float alp = 0f;
    private bool returnTitle = false;
    [SerializeField] private Image img;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (alp < 255)
        {
            alp += 1.0f;
        }

        img.color = new Color(255f, 255f, 255f, alp / 255f);

        
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
