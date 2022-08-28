using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionByCollision : InteractionBase
{
    public override string GetName()
    {
        return "Interacted with collision";
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            Interact();
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Player") {
            EndInteraction();
        }
    }
}
