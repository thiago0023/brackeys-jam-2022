using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyInteraction : InteractionByTrigger
{
    public static Action<int> IncreaseLight;
    private int darknessAmount;
    void Start()
    {
        var enemyStorage = GetComponent<EnemyStorage>();
        darknessAmount = enemyStorage.darknessAmount;
    }

    // void OnEnable()
    // {
    //     PlayerStorage.WispsAmountReturn += OnReceiveWispsAmount;
    // }

    // void OnDisable()
    // {
    //     PlayerStorage.WispsAmountReturn -= OnReceiveWispsAmount;
    // }

    public override string GetName()
    {
        return"Enemy Interaction";
    }

    public override void Interact()
    {
        Debug.Log(GetName());
        // PlayerStorage.GetWispsAmount?.Invoke();
    }

    private void OnReceiveWispsAmount(int amount)
    {
        if(amount > darknessAmount)
        {
            Destroy(this.gameObject);
        }
        else
        {
            PlayerActions.KillPlayer?.Invoke();
        }
    }
}
