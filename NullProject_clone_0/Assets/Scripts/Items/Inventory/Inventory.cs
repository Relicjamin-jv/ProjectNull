using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemUpdate();
    public OnItemUpdate OnItemUpdateCallBack; //allows us to sub to this and update it as need be

    public List<itemScriptable> items = new List<itemScriptable>(); //the array where the items will be stored

    public GameObject inventoryToggle;

    private int countInv = 0; 

    #region Singleton

    public static Inventory instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one inventory instance");
        }
        instance = this;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.instance.KeyDown("Inventory")){
            inventoryToggle.SetActive(!inventoryToggle.activeSelf);
        }
    }

    /// <summary>
    /// add an item to the list
    /// </summary>
    public void Add (itemScriptable item){
        if(countInv < 8){
            items.Add(item);
            countInv++;
        }else{
            Debug.Log("Inv space full");
        }
        if(OnItemUpdateCallBack != null){
            OnItemUpdateCallBack.Invoke();
        }
    }

    /// <summary>
    /// delete an item to the list
    /// </summary>
    public void Remove (itemScriptable item){
        if(countInv > 0){
            items.Remove(item);
            countInv--;
        }
        if(OnItemUpdateCallBack != null){
            OnItemUpdateCallBack.Invoke();
        }
    }

    /// <summary>
    /// only one item in a list but when more is added Ill add logic to it to make sure it works
    /// </summary>
    public void rollForLoot(){
        Add(LootTable.instance.lootRoll());
        Debug.Log("Added an item to items\n items contained: " + items.Count);
    }


}
