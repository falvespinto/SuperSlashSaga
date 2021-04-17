using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreSon : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 100;
        slider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreasedSlider()
    {
        Debug.Log("augmente ?");
        slider.value += 10;
    }

    public void DecreasedSlider()
    {
        Debug.Log("diminue ?");
        slider.value -= 10;
    }
}
