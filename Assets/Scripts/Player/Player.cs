using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController controller;
    public PlayerCondition condition;
    public PlayerMovement movement;

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
    }
}
