using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //움직임
    private Rigidbody playerRigidbody;
    private PlayerController playerController;

    private Vector3 moveDirection;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }
    void Start()
    {
        playerController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
    }

    private void Move(Vector2 dir)
    {
        Vector3 direction = transform.forward * dir.y + transform.right * dir.x;
        direction *= moveSpeed;
        direction.y = playerRigidbody.velocity.y;
        moveDirection = direction;
    }
    private void ApplyMovement(Vector3 dir)
    {
        playerRigidbody.velocity = dir;
    }
}
