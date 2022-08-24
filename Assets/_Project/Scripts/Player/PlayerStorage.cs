using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStorage : MonoBehaviour
{
    [SerializeField]
    private int wispsAmount = 0;
    void OnEnable()
    {
        WispInteraction.IncreaseLight += IncreaseLightAmount;
    }
    void OnDisable()
    {
        WispInteraction.IncreaseLight -= IncreaseLightAmount;
    }

    private void IncreaseLightAmount(int intensity)
    {
        wispsAmount++;
        print("Total wisps: " + wispsAmount);
    }
}
