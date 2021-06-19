using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    Inventory inventory;
    ItemSlot[] slots;

    private void Start() {
        inventory = Inventory.instance; //grabs the current inventory
        inventory.OnItemUpdateCallBack += UpdateUI;

    }

    private void Update() {
    
    }


    void UpdateUI(){
        slots = this.GetComponentsInChildren<ItemSlot>();

        for (int i = 0; i < slots.Length; i++){
            if(i < inventory.items.Count){ //if there is still more in the array then its time to add
                slots[i].AddItem(inventory.items[i]);
            }else{
                slots[i].clearSlot();
            }
        }
    }
}
