using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField] private float laserLength;

    //플레이어 레이어 마스크
    public LayerMask layerMask;

    Ray ray;
    RaycastHit hit;


    private void FixedUpdate()
    {
        LaserFire();
    }

    private void LaserFire()
    {
        ray = new Ray(transform.position, transform.forward * laserLength);
        Debug.DrawRay(transform.position, transform.forward * laserLength, Color.red);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, laserLength, layerMask))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                //닿으면 마지막 저장지점으로 돌아감
                CharacterManager.Instance.Player.controller.CallSavePointEvent();
            }
        }
    }
}
