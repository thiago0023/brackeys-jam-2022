using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hole : InteractionByTrigger
{
    public override void BeginInteraction()
    {
        throw new NotImplementedException();
    }

    public override void EndInteraction()
    {
        throw new NotImplementedException();
    }

    public override void Interact()
    {
        PlayerActions.KillPlayer?.Invoke();
    }
}
