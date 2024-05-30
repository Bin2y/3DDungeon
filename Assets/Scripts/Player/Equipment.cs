using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private Player player;
    private PlayerController controller;
    [SerializeField] private Transform equipSocket;

    ItemData equipData;

    private void Awake()
    {
        player = GetComponent<Player>();
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        player.equipItem += NewEquip;
        player.equipItem += ApplyEquipAbility;
        player.UnEquipItem += UnEquip;
        controller.DropWeaponEvent += UnEquip;
    }

    

    //아이템 장착 이벤트 발생
    private void NewEquip()
    {
        GameObject playerEquipData = player.equipData.equipPrefab;
        Instantiate(playerEquipData, equipSocket);
    }

    private void UnEquip()
    {
        if (player.equipData == null) return;
        equipData = player.equipData;
        for (int i = 0; i < equipData.equipables.Length; i++)
        {
            switch (equipData.equipables[i].type)
            {
                case EquipableType.speed:
                    CharacterManager.Instance.Player.movement.moveSpeed -= equipData.equipables[i].value;
                    break;
                case EquipableType.jumpPower:
                    CharacterManager.Instance.Player.movement.jumpPower -= equipData.equipables[i].value;
                    break;
            }
        }
        if (equipSocket.childCount != 0)
        {
            player.equipData = null;
            Destroy(equipSocket.GetChild(0).gameObject);
        }
    }


    private void ApplyEquipAbility()
    {
        equipData = player.equipData;
        if (equipData.type != ItemType.Equipable) return;

        for (int i = 0; i < equipData.equipables.Length; i++)
        {
            switch (equipData.equipables[i].type)
            {
                case EquipableType.speed:
                    CharacterManager.Instance.Player.movement.moveSpeed += equipData.equipables[i].value;
                    break;
                case EquipableType.jumpPower:
                    CharacterManager.Instance.Player.movement.jumpPower += equipData.equipables[i].value;
                    break;
            }
        }
    }
}
