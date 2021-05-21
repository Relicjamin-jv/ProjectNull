using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getKey : MonoBehaviour
{
    public KeyBindings KeyBindings;
    private string textControlName; //shown output of the string
    public GameObject controlName; //whats the keybind name
    public GameObject outPutFeild; //where to output the result too 

    private void Start() {
        KeyBindings.updateKey(KeyCode.T, "Focus"); //test sending keycode 
        textControlName = controlName.GetComponent<Text>().text.Split(' ')[0]; //gets the text for that control
        KeyCode keycode = getKeys(textControlName);
        outPutFeild.GetComponent<Text>().text = keycode.ToString();
       
    }

    private KeyCode getKeys(string keyCode){
        return KeyBindings.checkKey(keyCode);
    }
}
