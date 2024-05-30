using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public ItemData itemdata;
    public string GetInteractPrompt()
    {
        if (itemdata.type == ItemType.Interactable)
            return $"E키를 눌러 {itemdata.itemDesc}";
        return $"{itemdata.itemName}\n{itemdata.itemDesc}";
    }

    public void OnInteract()
    {
        if(itemdata.type != ItemType.Object)
        {
            switch(itemdata.type)
            {
                case ItemType.Equipable:
                    //데이터가 있다면 장착해제
                    if(CharacterManager.Instance.Player.equipData != null)
                    {
                        CharacterManager.Instance.Player.UnEquipItem?.Invoke();
                        //TODO : dropItem
                    }
                    CharacterManager.Instance.Player.equipData = itemdata;
                    CharacterManager.Instance.Player.equipItem?.Invoke();
                    break;
                case ItemType.Interactable:
                    break;
                default:
                    CharacterManager.Instance.Player.itemData = itemdata; break;
            }
            CharacterManager.Instance.Player.addItem?.Invoke();
            Destroy(gameObject);
        }
    }
}
