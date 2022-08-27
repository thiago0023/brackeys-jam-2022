using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float slowSpeed;
    private float currentSpeed;
    void Awake()
    {
        currentSpeed = speed;
        playerTransform = GetComponent<Transform>();
    }

    private void OnEnable() {
        SlowAreaInteraction.OnInteract += SlowAreaInteraction_OnInteract;
        SlowAreaInteraction.OnEndInteract += SlowAreaInteraction_OnEndInteract;
    }
    private void OnDisable() {
        SlowAreaInteraction.OnInteract -= SlowAreaInteraction_OnInteract;
        SlowAreaInteraction.OnEndInteract -= SlowAreaInteraction_OnEndInteract;
    }

    void LateUpdate(){
        Move();
    }
    private void Move()
    {
        Vector3 newVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        playerTransform.Translate( newVector * currentSpeed * Time.deltaTime);
    }
    private void SlowAreaInteraction_OnInteract()
    {
        ChangeSpeed(true);
    }
    private void SlowAreaInteraction_OnEndInteract()
    {
        ChangeSpeed(false);
    }

    private void ChangeSpeed(bool isSlow)
    {
        currentSpeed = isSlow ? slowSpeed : speed;
    }
}
