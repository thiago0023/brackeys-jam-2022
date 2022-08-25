using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStorage : MonoBehaviour
{
    public static Action<int> IncreaseLight;
    public static Action<int> DecreaseLight;
    public static Action<int> WispsAmountReturn;
    public static Action GetWispsAmount;

    [SerializeField]
    private int wispsAmount;

    void OnEnable()
    {
        IncreaseLight += IncreaseLightAmount;
        GetWispsAmount += OnGetWipsAmout;
    }
    void OnDisable()
    {
        IncreaseLight -= IncreaseLightAmount;
        GetWispsAmount -= OnGetWipsAmout;
    }

    private void IncreaseLightAmount(int intensity)
    {
        wispsAmount++;
    }

    private void OnGetWipsAmout()
    {
        WispsAmountReturn?.Invoke(wispsAmount);
    }
}
