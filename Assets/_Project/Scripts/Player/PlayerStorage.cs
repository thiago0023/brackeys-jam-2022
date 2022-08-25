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
    public static Func<bool> CanPlayerGiveWisps;

    [SerializeField]
    private int wispsAmount;

    void OnEnable()
    {
        IncreaseLight += IncreaseLightAmount;
        DecreaseLight += DecreaseLightAmount;
        GetWispsAmount += OnGetWipsAmout;
        CanPlayerGiveWisps += PlayerStorage_CanPlayerGiveWisps;
    }
    void OnDisable()
    {
        IncreaseLight -= IncreaseLightAmount;
        GetWispsAmount -= OnGetWipsAmout;
        CanPlayerGiveWisps += PlayerStorage_CanPlayerGiveWisps;
    }

    private void IncreaseLightAmount(int intensity)
    {
        wispsAmount++;
    }
    private void DecreaseLightAmount(int intensity)
    {
        wispsAmount--;
    }

    private void OnGetWipsAmout()
    {
        WispsAmountReturn?.Invoke(wispsAmount);
    }

    public bool PlayerStorage_CanPlayerGiveWisps()
    {
        return wispsAmount > 0;
    }
}
