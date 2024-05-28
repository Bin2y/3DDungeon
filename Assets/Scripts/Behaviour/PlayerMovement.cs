using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //움직임
    private Rigidbody playerRigidbody;
    private PlayerController playerController;

    private Vector2 moveDirection;
    [SerializeField] public float moveSpeed;

    //점프
    public LayerMask groundLayerMask;
    [SerializeField] public float jumpPower;
    public PlayerCondition playerCondition;
    public float jumpStamina;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        playerCondition = GetComponent<PlayerCondition>();
    }
    void Start()
    {
        playerController.OnMoveEvent += Move;
        playerController.OnJumpEvent += Jump;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            playerCondition.UseStamina(jumpStamina);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
    }

    private void Move(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void ApplyMovement(Vector2 dir)
    {
        Vector3 direction = transform.forward * dir.y + transform.right * dir.x;
        direction *= moveSpeed;
        direction.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = direction;
    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + transform.up * 0.01f, Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
}
