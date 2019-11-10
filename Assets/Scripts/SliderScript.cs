using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public static Slider slider;

    void Start()
    {
        InitSlider();
        
        slider.onValueChanged.AddListener(
            delegate {OverallSpeedChanged();}
            );
    }

    public void OverallSpeedChanged()
    {
        AllGlobalVariable.overallSpeed = slider.value;
    }

    void InitSlider()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.5f;
        slider.minValue = 0.5f;
        slider.maxValue = 4;
    }
}
