using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<itemScriptable> AllLoot = new List<itemScriptable>(); //the array where the items will be stored

    #region Simpleton
    public static LootTable instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("There is more than one instance of LootTable");
        }
        instance = this;
    }
    #endregion

    public itemScriptable lootRoll(){
        int random = Random.Range(0, 10);
        Debug.Log(random);
        return AllLoot[random];
    }
}
