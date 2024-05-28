using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformDirection
{
    right,
    left
}
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float platformSpeed;
    [SerializeField] private float timeToChangeDirection;
    private float curTime;
    private Rigidbody platformRigidbody;
    private PlatformDirection platformDirection;


    private void Awake()
    {
        platformRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        platformDirection = PlatformDirection.right;
        StartCoroutine(ChangePlatformDriection());
    }

    

    private void FixedUpdate()
    {
        MoveRightLeft();
    }

    private void MoveRightLeft()
    {
        switch(platformDirection)
        {
            case PlatformDirection.right:
                platformRigidbody.velocity = Vector3.right * platformSpeed * Time.deltaTime;
                break;
            case PlatformDirection.left:
                platformRigidbody.velocity = Vector3.left * platformSpeed * Time.deltaTime;
                break;
        }
    }

    public Vector3 GetPlatformMoving()
    {
        return platformRigidbody.velocity;
    }

    IEnumerator  ChangePlatformDriection()
    {
        if (platformDirection == PlatformDirection.right)
        {
            platformDirection = PlatformDirection.left;
        }
        else if (platformDirection == PlatformDirection.left)
        {
            platformDirection = PlatformDirection.right;
        }
        yield return new WaitForSeconds(timeToChangeDirection);
        StartCoroutine(ChangePlatformDriection());  
    }
}
