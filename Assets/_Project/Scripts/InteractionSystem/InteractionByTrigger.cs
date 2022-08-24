using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionByTrigger : InteractionBase
{
    public override string GetName()
    {
        return "Interacted with trigger";
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Interact();
        }
    }
}
