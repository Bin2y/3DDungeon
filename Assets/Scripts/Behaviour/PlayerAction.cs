using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private PlayerCondition playerConditon;
    private Rigidbody playerRigidbody;

    public float climbSpeed;
    public float climbStamina;
    public bool isHang;
    public bool isClimb;

    public float maxDistance;
    public LayerMask layerMask;
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        playerConditon = GetComponent<PlayerCondition>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        CheckWall();
    }

    private void CheckWall()
    {
        ray = new Ray(transform.position, transform.forward + (-transform.up));
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            ClimbWall();
        }
        isClimb = false;
    }
    private void ClimbWall()
    {
        isClimb = true;
        playerRigidbody.velocity = Vector3.up * climbSpeed;
        playerConditon.uiCondition.stamina.Subtract(climbStamina * Time.deltaTime);
    }
}
