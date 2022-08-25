using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIntensity : MonoBehaviour
{
    public static Action TurnOffLight;
    [SerializeField]
    private float decreaseSpeed;
    private Light lightObject;
    private float luminositySteps = 0.06f;
    private float intensityBySpotSize = 20f;
    private bool isIncreasing = false;
    void Awake()
    {
        lightObject = GetComponentInChildren<Light>();
        DecreaseIntensity();
    }

    void OnEnable()
    {
        PlayerStorage.IncreaseLight += IncreaseIntensity;
        TurnOffLight += OnTurnOff;
    }
    void OnDisable()
    {
        PlayerStorage.IncreaseLight -= IncreaseIntensity;
        TurnOffLight -= OnTurnOff;
    }

    void IncreaseIntensity(int intensity)
    {
        StartCoroutine(LightIncreaseIntensityEase(lightObject.spotAngle + intensity));
    }

    void DecreaseIntensity()
    {
        StartCoroutine(LightDecreaseIntensityEase());
    }

    void OnTurnOff()
    {
        lightObject.spotAngle = 0;
        lightObject.intensity = 0;
    }

    IEnumerator LightIncreaseIntensityEase(float newIntensity)
    {
        isIncreasing = true;
        while(lightObject.spotAngle <= newIntensity)
        {
            lightObject.spotAngle += luminositySteps;
            lightObject.intensity = lightObject.spotAngle/intensityBySpotSize;
            yield return null;
        }
        isIncreasing = false;
    }

    IEnumerator LightDecreaseIntensityEase()
    {
        yield return new WaitWhile(() => isIncreasing);
        lightObject.spotAngle -= Time.deltaTime * decreaseSpeed;
        lightObject.intensity = lightObject.spotAngle/intensityBySpotSize;
        if(lightObject.spotAngle > 1)
        {
            DecreaseIntensity();
        }
        else
        {
            lightObject.enabled = false;
            print("Player's Dead");
        }
    }
}
