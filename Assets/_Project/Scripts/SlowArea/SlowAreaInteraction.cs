using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlowAreaInteraction : InteractionByTrigger
{
    public static event Action OnInteract;
    public static event Action OnEndInteract;

    public override void BeginInteraction()
    {
        throw new NotImplementedException();
    }

    public override void EndInteraction()
    {
        OnEndInteract?.Invoke();
    }

    public override void Interact()
    {
        OnInteract?.Invoke();
    }
}
