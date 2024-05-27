using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentItemSlot : MonoBehaviour
{
    public ItemData itemdata;
    public Image itemSpriteRenderer;

    private void Update()
    {
        ExpressMainSlotUI();
    }

    private void ExpressMainSlotUI()
    {
        if (CharacterManager.Instance.Player.itemData != null)
        {
            itemdata = CharacterManager.Instance.Player.itemData;
            itemSpriteRenderer.sprite = itemdata.icon;
        }
        else
        {
            itemSpriteRenderer.sprite = null;
        }
    }

}
