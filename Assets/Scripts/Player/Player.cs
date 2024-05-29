using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        movement = GetComponent<PlayerMovement>();
        _rigidbody = GetComponent<Rigidbody>();
    }
}
