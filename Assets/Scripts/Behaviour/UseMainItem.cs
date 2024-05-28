using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//현재 장착중인 아이템을 사용
public class UseMainItem : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerMovement playerMovement;

    private ItemData itemData;

    private float boosterDuration = 3f;
    private float doubleJumpDuration = 5f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        playerController.OnUseItemEvent += UseItem;
    }

    private void UseItem()
    {
        itemData = CharacterManager.Instance.Player.itemData;
        if (itemData.type != ItemType.Consumable) return;
    
        for (int i = 0; i < itemData.consumables.Length; i++)
        {
            switch (itemData.consumables[i].type)
            {
                case ConsumableType.Health:
                    break;
                case ConsumableType.Hunger:
                    break;
                case ConsumableType.Speed:
                    StartCoroutine(Boost(itemData.consumables[i].value));
                    break;
                case ConsumableType.DoubleJump:
                    StartCoroutine(DoubleJumpEvent());
                    break;
            }
        }
        CharacterManager.Instance.Player.itemData = null;
    }

    private IEnumerator DoubleJumpEvent()
    {
        playerMovement.SubDoubleJump();
        yield return new WaitForSeconds(doubleJumpDuration);
        playerMovement.CancleSubDoubleJump();
    }

    //TODO : 부스트기능이랑 아이템 사용 기능이랑 분리해보기?
    IEnumerator Boost(float value)
    {
        float tempMoveSpeed = playerMovement.moveSpeed;
        playerMovement.moveSpeed += value;
        yield return new WaitForSeconds(boosterDuration);
        playerMovement.moveSpeed = tempMoveSpeed;
    }
}
