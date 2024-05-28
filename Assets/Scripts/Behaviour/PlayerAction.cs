using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAction : MonoBehaviour
{
    private PlayerCondition playerConditon;
    private Rigidbody playerRigidbody;
    private PlayerController playerController;

    public float climbSpeed;
    public float climbStamina;
    private float minClimbStamina = 10f;
    private float coolDown = 3f; //스태미나가 최소치를 넘겼을때 벽을 타기위해 기다려야하는 시간
    public bool canHang;
    public bool canClimb;

    public float maxDistance;
    public LayerMask layerMask;
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        playerConditon = GetComponent<PlayerCondition>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }


    private void FixedUpdate()
    {
        CheckWall();
    }

    private void Start()
    {
        playerController.OnWallWalkEvent += IsWallWalking;
    }
    private void CheckWall()
    {
        ray = new Ray(transform.position, transform.forward + (-transform.up));
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            if (playerConditon.uiCondition.stamina.curValue <= minClimbStamina)
            {
                StartCoroutine(CoolDownClimbWall());
                return;
            }
            ClimbWall();
        }
    }
    private void ClimbWall()
    {
        if (canClimb)
        {
            playerRigidbody.velocity = Vector3.up * climbSpeed;
            playerConditon.uiCondition.stamina.Subtract(climbStamina * Time.deltaTime);
        }
    }
    private void IsWallWalking(bool canWallWalk)
    {
        canClimb = canWallWalk;
    }

    IEnumerator CoolDownClimbWall()
    {
        canClimb = false;
        yield return new WaitForSeconds(coolDown);
        canClimb = true;
    }
}
