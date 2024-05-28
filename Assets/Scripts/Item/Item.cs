using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public ItemData itemdata;
    public string GetInteractPrompt()
    {
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
                    CharacterManager.Instance.Player.equipData = itemdata; break;
                default:
                    CharacterManager.Instance.Player.itemData = itemdata; break;
            }
            CharacterManager.Instance.Player.equipItem?.Invoke();
            CharacterManager.Instance.Player.addItem?.Invoke();
            Destroy(gameObject);
        }
    }
}
