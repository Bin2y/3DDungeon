using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public PlayerMovement movement;
    public Rigidbody _rigidbody;

    public ItemData itemData;
    public ItemData equipData;


    public Action addItem;
    public Action equipItem;
    public Action UnEquipItem;

    //세이브 포인트
    public Vector3 savePoint;
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        movement = GetComponent<PlayerMovement>();
        _rigidbody = GetComponent<Rigidbody>();
    }
}
