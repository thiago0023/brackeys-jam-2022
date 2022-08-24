using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntensity : MonoBehaviour
{
    private Light light;
    void Awake()
    {
        light = GetComponentInChildren<Light>();
        print(light);
    }

    void OnEnable()
    {
        WispInteraction.AddLightIntensity += AddIntensity;
    }

    void AddIntensity(int intensity)
    {
        // now lerp light intensity
        light.intensity = Mathf.Lerp(light.intensity, light.intensity + intensity/10 , 5f);

        light.spotAngle += intensity;
        // light.intensity += intensity/10;
    }

}
