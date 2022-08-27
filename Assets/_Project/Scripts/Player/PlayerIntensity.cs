using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIntensity : MonoBehaviour
{
    public static event Action OnLightOff;
    public static Action TurnOffLight;
    [SerializeField]
    private float decreaseSpeed;
    [SerializeField]
    private float decreaseSpeedFaster;
    private float currenteDecreaseSpeed;
    private Light lightObject;
    private float luminositySteps = 0.06f;
    private float intensityBySpotSize = 10f;
    private bool isIncreasing = false;
    void Awake()
    {
        lightObject = GetComponentInChildren<Light>();
        DecreaseIntensity();
        currenteDecreaseSpeed = decreaseSpeed;
    }

    void OnEnable()
    {
        PlayerStorage.OnIncreaseWisp += PlayerStorage_OnIncreaseWisp;
        PlayerStorage.OnDecreaseWisp += PlayerStorage_OnDecreaseWisp;
        SlowAreaInteraction.OnInteract += SlowAreaInteraction_OnInteract;
        SlowAreaInteraction.OnEndInteract += SlowAreaInteraction_OnEndInteract;
        TurnOffLight += OnTurnOff;
    }
    void OnDisable()
    {
        PlayerStorage.OnIncreaseWisp -= PlayerStorage_OnIncreaseWisp;
        PlayerStorage.OnDecreaseWisp -= PlayerStorage_OnDecreaseWisp;
        SlowAreaInteraction.OnInteract -= SlowAreaInteraction_OnInteract;
        SlowAreaInteraction.OnEndInteract -= SlowAreaInteraction_OnEndInteract;
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
        lightObject.spotAngle -= Time.deltaTime * currenteDecreaseSpeed;
        lightObject.intensity = lightObject.spotAngle/intensityBySpotSize;
        if(lightObject.spotAngle > 1)
        {
            DecreaseIntensity();
        }
        else
        {
            LightOff();
        }
    }

    private void LightOff()
    {
        lightObject.enabled = false;
        OnLightOff?.Invoke();
    }

    private void PlayerStorage_OnIncreaseWisp(object sender, int intensity)
    {
        IncreaseIntensity(intensity);
    }

    private void PlayerStorage_OnDecreaseWisp(object sender, EventArgs e)
    {
        Debug.Log("Criar lógica de diminuir a intensidade");
    }

    private void SlowAreaInteraction_OnInteract()
    {
        ChangeSpeed(true);
    }
    private void SlowAreaInteraction_OnEndInteract()
    {
        ChangeSpeed(false);
    }

    private void ChangeSpeed(bool isFater)
    {
        currenteDecreaseSpeed = isFater ? decreaseSpeedFaster : decreaseSpeed;
    }
}
