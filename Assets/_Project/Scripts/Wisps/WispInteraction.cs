using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WispInteraction : InteractionByTrigger
{
    [SerializeField]
    private int addIntensity;

    public override string GetName()
    {
        return"Wisp Interaction";
    }

    public override void Interact()
    {
        Debug.Log(GetName());
        PlayerStorage.IncreaseLight?.Invoke(addIntensity);
        Destroy(this.gameObject);
    }
}
