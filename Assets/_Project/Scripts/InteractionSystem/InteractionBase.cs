using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InteractionBase : MonoBehaviour, IInteractable
{
    public abstract void BeginInteraction();

    public abstract void EndInteraction();

    public abstract string GetName();
    public abstract void Interact();

}
