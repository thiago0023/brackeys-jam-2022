using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeInteractable : MonoBehaviour, IInteractable
{

    [SerializeField] private List<GameObject> interactables = new List<GameObject>();

    private void Awake() {
        
    }
    public string GetName()
    {
        return "Super interação!!!";
    }

    public void Interact()
    {
        foreach (GameObject interactable in interactables) {
            if (interactable.TryGetComponent<IInteractable>(out IInteractable interactableComponent)) {
                interactableComponent.Interact();
            }
        }
    }
}
