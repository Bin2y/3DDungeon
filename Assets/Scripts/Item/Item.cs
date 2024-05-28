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
            CharacterManager.Instance.Player.itemData = itemdata;
            CharacterManager.Instance.Player.addItem?.Invoke();
            Destroy(gameObject);
        }
    }
}
