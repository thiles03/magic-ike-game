using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBarController : MonoBehaviour
{
    public Slider slider;

    public void SetSliderMax(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }
    public void SliderValue(float value)
    {
        slider.value = value;
    }
}
