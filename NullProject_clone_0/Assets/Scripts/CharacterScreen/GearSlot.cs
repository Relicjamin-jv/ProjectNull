using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GearSlot : MonoBehaviour, IDropHandler
{
    public Image icon;
    public itemScriptable item;
    private GameObject mainWeapon;
    public bool head;
    public bool chest;
    public bool foot;
    public bool weapon;
    public bool offHandWeapon;
    public bool ranged;
    public bool bracer;

    public delegate void updateStats();
    public static event updateStats updateUI;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            item = eventData.pointerDrag.GetComponentInParent<ItemSlot>().item;
            if (this.head && item.head)
            {
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[0] = item;
                Inventory.instance.Remove(item);
            }
            else if (this.chest && item.chest)
            {
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[1] = item;
                Inventory.instance.Remove(item);
            }
            else if (this.foot && item.foot)
            {
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[2] = item;
                Inventory.instance.Remove(item);
            }
            else if (this.weapon && item.twoHanded)
            {
                CanEquip.setTwoHanded(true);
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[2] = item;
                Debug.Log("QUESUS!!!!");
                Inventory.instance.Remove(item);
            }
            else if (this.weapon && item.oneHanded)
            {
                CanEquip.setTwoHanded(false);
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[3] = item;
                Inventory.instance.Remove(item);
            }
            else if (this.offHandWeapon && item.oneHanded && CanEquip.twoHanded == false)
            {
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[4] = item;
                Inventory.instance.Remove(item);
            }
            else if (this.offHandWeapon && item.offHand) //sheild
            {
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[4] = item;
                Inventory.instance.Remove(item);
            }
            else if (this.ranged && item.ranged)
            {
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[5] = item;
                Inventory.instance.Remove(item);
            }
            else if (this.bracer && item.bracers)
            {
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                EquipedGear.instance.gearArray[6] = item;
                Inventory.instance.Remove(item);
            }
            updateUI();
        }
    }

    public void removeItem(itemScriptable item)
    {
        if (this.head && item.head)
        {
            EquipedGear.instance.gearArray[0] = null;
        }
        else if (this.chest && item.chest)
        {
            EquipedGear.instance.gearArray[1] = null;
        }
        else if (this.foot && item.foot)
        {
            EquipedGear.instance.gearArray[2] = null;
        }
        else if (this.weapon && item.twoHanded)
        {
            CanEquip.setTwoHanded(false);
            EquipedGear.instance.gearArray[2] = null;
        }
        else if (this.weapon && item.oneHanded)
        {
            EquipedGear.instance.gearArray[3] = null;
        }
        else if (this.offHandWeapon && item.oneHanded && CanEquip.twoHanded == false)
        {
            EquipedGear.instance.gearArray[4] = null;
        }
        else if (this.offHandWeapon && item.offHand) //sheild
        {
            EquipedGear.instance.gearArray[4] = null;
        }
        else if (this.ranged && item.ranged)
        {
            EquipedGear.instance.gearArray[5] = null;
        }
        else if (this.bracer && item.bracers)
        {
            EquipedGear.instance.gearArray[6] = null;
        }
        updateUI();
    }

    public void clearSlot(){
        item = null;
        icon.sprite = null;
    }
}
