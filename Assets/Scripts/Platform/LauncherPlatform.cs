using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherPlatform : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerController playerController;
    private Transform playerTransform;


    [Header("Charge")]
    public float maxChargeTime;
    public float minChargeTime;
    public float chargeTime;
    public bool isCharge;
    [Header("Launch")]
    public float launcherPower;
    public Vector3 launcherDirection;

    private void Start()
    {
        playerRigidbody = CharacterManager.Instance.Player._rigidbody;
        playerController = CharacterManager.Instance.Player.controller;
        isCharge = false;
    }

    //런치 플랫폼위에 올라오면 작동하게구현
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.OnChargeEvent += Charge;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.OnChargeEvent -= Charge;
            isCharge = false;
        }
    }
    private void FixedUpdate()
    {
        if (isCharge)
        {
            chargeTime += Time.deltaTime;
        }
    }
    private void Charge()
    {
        if (!isCharge)
        {
            isCharge = true;
            chargeTime = 0;
        }
        else
        {
            isCharge = false;
            Launch();
        }
    }

    private void Launch()
    {
        if (chargeTime < minChargeTime) return;
        if (chargeTime > maxChargeTime)
            chargeTime = maxChargeTime;
        launcherDirection = (playerTransform.right + playerTransform.up).normalized;
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.AddForce(launcherDirection * launcherPower * chargeTime,ForceMode.Impulse);
    }
}
