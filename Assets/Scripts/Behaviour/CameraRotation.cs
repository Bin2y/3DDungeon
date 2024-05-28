using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private PlayerController playerController;

    private Vector2 mouseDelta;

    [SerializeField] private float camCurXRot;
    [SerializeField] private float minXLook, maxXLook;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private Transform cameraContainer;

    [Header("Thrid Person View")]
    public float camPosX3rd;
    public float camPosY3rd;
    public float camPosZ3rd;
    public bool isThridPerson;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    void Start()
    {
        playerController.OnLookEvent += Look;
        playerController.OnViewToggleEvent += ViewToggle;
    }

    private void ViewToggle()
    {
        if (isThridPerson)
        {
            cameraContainer.localPosition = new Vector3(0, 0, 0);
            isThridPerson = false;
        }
        else
        {
            cameraContainer.localPosition = new Vector3(camPosX3rd, camPosY3rd, camPosZ3rd);
            isThridPerson = true;
        }    
            
    }

    private void LateUpdate()
    {
        CameraLook(mouseDelta);
    }

    private void Look(Vector2 mouseDelta)
    {
        this.mouseDelta = mouseDelta;
    }
    private void CameraLook(Vector2 mouseDelta)
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }
}
