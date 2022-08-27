using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hole : InteractionByTrigger
{
    public override void Interact()
    {
        PlayerActions.KillPlayer?.Invoke();
    }
}
