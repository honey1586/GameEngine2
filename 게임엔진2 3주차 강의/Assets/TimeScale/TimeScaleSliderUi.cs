using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSliderUi : MonoBehaviour
{
    public void OnvalueChanged(float value)
    {
        Time.timeScale = value;
    }
}
