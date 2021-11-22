using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    private Volume globalVolume;
    ColorAdjustments colorAdjustments;
    Vignette vignette;
    WhiteBalance whiteBalance;
    private void Awake()
    {
        globalVolume = GetComponent<Volume>();
    }
    private void Start()
    {
        globalVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        globalVolume.profile.TryGet<Vignette>(out vignette);
        globalVolume.profile.TryGet<WhiteBalance>(out whiteBalance);
    }
    private void OnEnable()
    {
        UltimateAttackYuetsu.OnYuetsuUltimate += SetPostProcessingToYuetsu;
        UltimateAttackYuetsu.OnUltimateEnd += SetPostProcessingToNormal;
    }
    private void OnDisable()
    {
        UltimateAttackYuetsu.OnYuetsuUltimate -= SetPostProcessingToYuetsu;
        UltimateAttackYuetsu.OnUltimateEnd -= SetPostProcessingToNormal;
    }
    private void SetPostProcessingToYuetsu()
    {
        colorAdjustments.saturation.value = -2;
        colorAdjustments.colorFilter.overrideState = true;
        //colorAdjustments.colorFilter.value = new Color(164, 198, 231);

        vignette.intensity.value = 0.505f;
        whiteBalance.temperature.value = -50;

    }

    private void SetPostProcessingToNormal()
    {
        colorAdjustments.saturation.value = 5;
        colorAdjustments.colorFilter.overrideState = false;

        vignette.intensity.value = 0.53f;
        whiteBalance.temperature.value = 5;
    }

}
