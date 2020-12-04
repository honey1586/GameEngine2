using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour
{
    private float timer;
    private float alp = 0f;
    private bool returnTitle = false;
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI timerText;
    public PlayTimer p_timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (alp < 255)
        {
            alp += 1.0f;
        }

        img.color = new Color(255f, 255f, 255f, alp / 255f);   
        timerText.color = new Color(0f, 0f, 0f, alp / 255f);
        
        int minute = ((int) p_timer.playTime / 60);
        int second = (int) p_timer.playTime % 60;
        timerText.text = "PlayTime : " + minute.ToString() + " : " + second.ToString();
        p_timer.isFinish = true;
        if (timer >= 3.0f && Input.GetMouseButtonDown(0))
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
