using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.F;
    [SerializeField] private float interactRadius = 2f;

    [SerializeField] private LayerMask interactableLayer;

    private List<InteractionWithKey> GetNearestInteractableObjects() {
        List<InteractionWithKey> interactables = new List<InteractionWithKey>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRadius, interactableLayer);
        foreach (Collider collider in colliders) {
            InteractionWithKey interactable = collider.GetComponent<InteractionWithKey>();
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
