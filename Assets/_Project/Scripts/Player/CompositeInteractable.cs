using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeInteractable : InteractionWithKey
{

    [SerializeField] private List<GameObject> interactables = new List<GameObject>();

    private void Awake() {
        
    }
    public override string GetName()
    {
        return "Super interação!!!";
    }

    public override void Interact()
    {
        foreach (GameObject interactable in interactables) {
            if (interactable.TryGetComponent<IInteractable>(out IInteractable interactableComponent)) {
                interactableComponent.Interact();
            }
        }
    }
}
