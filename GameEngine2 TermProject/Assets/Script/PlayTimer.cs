using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimer : MonoBehaviour
{
    public float playTime;

    public bool isFinish = false;
    // Start is called before the first frame update
    void Awake()
    {
        playTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinish)
        {
            playTime += Time.deltaTime;
        }
    }
}
