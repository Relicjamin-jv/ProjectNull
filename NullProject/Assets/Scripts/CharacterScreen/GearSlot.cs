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

    private EquipedGear gear;

    private void Awake()
    {
        gear = EquipedGear.instance;
    }

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
                gear.gearArray[3] = item;
                Inventory.instance.Remove(item);
            }
            else if (this.weapon && item.oneHanded)
            {
                CanEquip.setTwoHanded(false);
                icon.sprite = eventData.pointerDrag.GetComponentInParent<ItemSlot>().icon.sprite;
                gear.gearArray[3] = item;
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
        }
    }
}
