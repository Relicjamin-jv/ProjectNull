using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   public static InputManager instance;

   public KeyBindings keyBindings;

    //calls when the script first starts, if it exists then it will delete itself, if it doesnt not exist then it will become the intance of the input manager
   private void Awake() {
       if(instance == null){
           instance = this;
       }else if(instance != this){
           Destroy(this);
       }
       DontDestroyOnLoad(this); //persist through scenes
   } 

    //whether were pressing the button or not
   public bool KeyDown(string key){
       if(Input.GetKeyDown(keyBindings.checkKey(key))){
           return true;
       }else{
           return false;
       }
   }
}
