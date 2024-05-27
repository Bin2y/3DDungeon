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

}
