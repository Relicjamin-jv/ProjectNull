using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " KeyBindings", menuName = "KeyBindings")]
public class KeyBindings : ScriptableObject
{
    public KeyCode focus; //add more here as needed

    public KeyCode checkKey(string key){
        switch(key){
            case "focus":
                return focus;
            default:
                return KeyCode.None;
        }
    }
}
