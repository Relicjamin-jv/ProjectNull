using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " KeyBindings", menuName = "KeyBindings")]
public class KeyBindings : ScriptableObject
{
    public KeyCode Focus; //add more here as needed
    public KeyCode Inventory;

    public KeyCode checkKey(string key){
        switch(key){
            case "Focus":
                return Focus;
            case "Inventory":
                return Inventory;
            default:
                return KeyCode.None;
        }
    }

    public void updateKey(KeyCode control, string key){
        //TODO implement:
        switch(key){
            case "Focus":
                Focus = control;
                return;
            case "Inventory":
                Inventory = control;
                return;
            default:
                Debug.Log("No key");
                return;
        }
    }

}
