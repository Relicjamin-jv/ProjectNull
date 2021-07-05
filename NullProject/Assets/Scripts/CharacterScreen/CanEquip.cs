using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanEquip : MonoBehaviour
{
    public GearSlot mainWeapon;
    public static bool twoHanded = false;

    public static void setTwoHanded(bool value){
        twoHanded = value;
    }
}
