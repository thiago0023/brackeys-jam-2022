using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInteractable
{
    public string GetName();

    public void Interact();

    public void BeginInteraction();

    public void EndInteraction();
}
