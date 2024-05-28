using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Resource,
    Interactable,
    Object
}

public enum ConsumableType
{
    Health,
    Hunger,
    Speed,
    DoubleJump
}

public enum EquipableType
{
    speed,
    jumpPower
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[Serializable]
public class ItemDataEquipable
{
    public EquipableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("ItemInfo")]
    public string itemName;
    public string itemDesc;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Equip")]
    public GameObject equipPrefab;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Equipable")]
    public ItemDataEquipable[] equipables;
}
