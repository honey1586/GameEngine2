using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneEvent : MonoBehaviour
{
    [SerializeField] private GameObject userInter;
    public void OnClickStartButton()
    {
        gameObject.SetActive(false);
        userInter.SetActive(true);
    }
}
