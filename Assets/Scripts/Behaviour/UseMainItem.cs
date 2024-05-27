using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//현재 장착중인 아이템을 사용
public class UseMainItem : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerController playerController;
    private ItemData itemData;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        playerController.OnUseItemEvent += useItem;
    }

    private void useItem()
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
                    break;
            }
        }
    }
}
