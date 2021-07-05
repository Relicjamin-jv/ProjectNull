using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GearSlot : MonoBehaviour, IDropHandler
{
    public Image icon;
    public itemScriptable item;

    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
            icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
            item = eventData.pointerDrag.GetComponentInParent<ItemSlot>().item;
            Inventory.instance.Remove(item); //removes the item from the inventory section
        }
    }
}
