using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WispInteraction : InteractionByTrigger
{
    [SerializeField]
    private int addIntensity;
    public static event EventHandler OnInteracted;

    public override void BeginInteraction()
    {
        throw new NotImplementedException();
    }

    public override void EndInteraction()
    {
        throw new NotImplementedException();
    }

    public override string GetName()
    {
        return"Wisp Interaction";
    }

    public override void Interact()
    {
        Debug.Log(GetName());
        OnInteracted?.Invoke(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
}
