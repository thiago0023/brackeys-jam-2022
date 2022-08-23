using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField]
    private float speed;
    void Awake()
    {
        playerTransform = GetComponent<Transform>();
    }

    void LateUpdate(){
        Move();
    }
    public void Move(){
        Vector3 newVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerTransform.Translate( newVector * speed * Time.deltaTime);
    }
}
