using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    const string previousVolumeParameter = "previousVolumeParameter";
    [SerializeField] string volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider slider;
    [SerializeField]  float multiplier = 30f;
    [SerializeField] Toggle toggle;
    private bool disableToggleEvent;

    void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
        toggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }


    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }
    private void HandleToggleValueChanged(bool enableSound)
    {
        if(disableToggleEvent)
        {
            return;
        }
        if (enableSound)
        {
            slider.value = PlayerPrefs.GetFloat(previousVolumeParameter, slider.maxValue);
        }
        else
        {
            PlayerPrefs.SetFloat(previousVolumeParameter, slider.value);
            slider.value = slider.minValue;
        }

    }

    private void HandleSliderValueChanged(float value)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(value)* multiplier);
        disableToggleEvent = true;
        toggle.isOn = slider.value > slider.minValue;
        disableToggleEvent = false;
    }



    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
