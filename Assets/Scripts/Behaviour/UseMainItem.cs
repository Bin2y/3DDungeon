using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//현재 장착중인 아이템을 사용
//놓을 수 있는 아이템이면 플레이어 전방에 놓는다.
public class UseMainItem : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerMovement playerMovement;
    private Transform playerTransform;

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

        if (itemData.type == ItemType.Placeable)
        {
            PlaceItem();
            CharacterManager.Instance.Player.itemData = null;
            return;
        }

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

    private void PlaceItem()
    {
        GameObject placeItem = itemData.placePrefab;
        Instantiate(placeItem, gameObject.transform.position + transform.forward - transform.up, Quaternion.identity);
    }

    private IEnumerator DoubleJumpEvent()
    {
        playerMovement.SubDoubleJump();
        yield return new WaitForSeconds(doubleJumpDuration);
        playerMovement.CancleSubDoubleJump();
    }

    IEnumerator Boost(float value)
    {
        float tempMoveSpeed = playerMovement.moveSpeed;
        playerMovement.moveSpeed += value;
        yield return new WaitForSeconds(boosterDuration);
        playerMovement.moveSpeed = tempMoveSpeed;
    }
}
