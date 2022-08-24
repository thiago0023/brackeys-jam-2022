using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.F;
    [SerializeField] private List<IInteractable> interactables = new List<IInteractable>();
    [SerializeField] private float interactRadius = 2f;

    [SerializeField] private LayerMask interactableLayer;

    private List<IInteractable> GetNearestInteractableObjects() {
        interactables.Clear();
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRadius, interactableLayer);
        foreach (Collider collider in colliders) {
            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null) {
                interactables.Add(interactable);
            }
        }
        
        return interactables;
    }

    private void Update() {
        var interactableObjects = GetNearestInteractableObjects();
        if (interactableObjects.Count == 0) return;

        if(Input.GetKeyDown(interactKey)) {
            interactableObjects.ForEach(interactable => interactable.Interact());
        }

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }


}
