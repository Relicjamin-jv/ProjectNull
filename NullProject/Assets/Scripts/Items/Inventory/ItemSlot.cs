using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
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

    public void onEquip(){
        EquipedGear.instance.setGear(item);
        
    }
}
