using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedGear : MonoBehaviour
{
    public itemScriptable[] gearArray = new itemScriptable[7]; // 1. head, 2. cheast, 3. feet, 4. main weap. , 5. off weapon, 6. ranged, 7. bracer

    #region Singleton

    public static EquipedGear instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one instance of the gear");
        }
        instance = this;
    }

    #endregion

    public void setGear(itemScriptable item)
    {
        gearArray[0] = item;
    }

}
