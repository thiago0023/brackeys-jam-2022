using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InteractionBase : MonoBehaviour, IInteractable
{
    public abstract string GetName();
    public abstract void Interact();

}
