using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class CameraShake : MonoBehaviour
{
    CameraShakeInstance cameraShakeInstance;
    public float magnitude = 4f;
    public float roughness = 4f;
    public float fadeInTime = 0.1f;
    public float fadeOutTime = 1f;

    public float bigMagnitude = 4f;
    public float bigRoughness = 4f;
    public float bigFadeInTime = 0.1f;
    public float bigFadeOutTime = 1f;

    public void ShakeCamera()
    {
        cameraShakeInstance = CameraShaker.GetInstance("Virtual Camera 1").StartShake(magnitude, roughness, fadeInTime);
    }
    public void StopShake()
    {
        cameraShakeInstance.StartFadeOut(fadeOutTime);
    }

    public void BigShake()
    {
        CameraShaker.GetInstance("Virtual Camera 2").ShakeOnce(bigMagnitude, bigRoughness, bigFadeInTime, bigFadeOutTime);
    }
}
