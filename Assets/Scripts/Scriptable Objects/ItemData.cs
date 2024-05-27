using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable,
    Resource
}
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("ItemInfo")]
    public string itemName;
    public string itemDesc;
    public ItemType type;
    public GameObject dropPrefab;

    [Header("Equip")]
    public GameObject equipPrefab;

}
