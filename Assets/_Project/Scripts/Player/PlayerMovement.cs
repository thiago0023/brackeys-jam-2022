using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField] private float speed;
    [SerializeField] private float slowSpeed;
    private float currentSpeed;
    private Camera cam;
    private CharacterController _controller;
    [SerializeField] private float gravity = 0.5f;
    void Awake()
    {
        currentSpeed = speed;
        playerTransform = GetComponent<Transform>();
    }

    void Start()
    {
        cam = Camera.main;
        _controller = GetComponent<CharacterController>();
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
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();    

        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;
        desiredMoveDirection.y = gravity * (-1);
        _controller.Move(desiredMoveDirection * Time.deltaTime * currentSpeed);
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
