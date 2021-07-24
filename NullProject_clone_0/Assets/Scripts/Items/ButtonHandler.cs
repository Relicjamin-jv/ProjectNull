using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void btnToRoll(){
        Inventory.instance.rollForLoot();
        Debug.Log("Rolled for loot");
    }
}
