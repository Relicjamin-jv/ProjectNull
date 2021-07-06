using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public Image icon;
    public itemScriptable item;
    public Button removeButton;

    public void AddItem(itemScriptable newItem){
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void clearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void onRemove(){
        Inventory.instance.Remove(item);
    }

     public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
            //add the item to the inventory
            GearSlot info = eventData.pointerDrag.GetComponent<GearSlot>();
            Inventory.instance.Add(info.item);
            //remove the item from the gear
            info.removeItem(info.item);
            info.clearSlot();
        }
    }
    
}
