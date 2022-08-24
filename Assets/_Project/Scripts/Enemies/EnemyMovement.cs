using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float interactRadius = 2f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float damping = 2f;
    [SerializeField] private float moveSpeed = 2f;


    void Update()
    {
        var targetFound = LookingForTarget();
        if (!targetFound) return;

        LookAtTarget(targetFound);
        TargetFollow();
    }

    private Transform LookingForTarget()
    {
        Transform targetTransform = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRadius, interactableLayer);
        foreach (Collider collider in colliders) {
            if (collider.gameObject.CompareTag("Player")) {
                targetTransform = collider.GetComponent<Transform>();
            }
        }
        return targetTransform;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }

    private void LookAtTarget(Transform targetTransform)
    {
        var lookPos = targetTransform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    private void TargetFollow()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }
}
