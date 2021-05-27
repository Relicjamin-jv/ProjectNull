using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class getKeyandSetKey : MonoBehaviour
{
    public KeyBindings KeyBindings; //the keybindings
    public GameObject controlName; //the name of the control
    public GameObject currentControl; //the control it's currently mapped to
    public InputField userInput; //the users input
    string control; //store the control


    //when the option menu is pulled up it grabs the key automatically
    private void Start()
    {
        control = controlName.GetComponent<Text>().text; //grabs the control name
        currentControl.GetComponent<Text>().text = KeyBindings.checkKey(control).ToString(); //one huge line but it grabs the name of the control and sends it
    }


    //checks if the key is the same, if not it updates to the new controls
    private void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
            {
                Debug.Log("KeyCode down: " + kcode);
                switch (kcode)
                {
                    case KeyCode.Return:
                        userInput.text = "";
                        userInput.text = "Enter";
                        break;
                    case KeyCode.Backspace:
                        userInput.text = "";
                        userInput.text = "BackSpace";
                        break;
                    case KeyCode.UpArrow:
                        userInput.text = "";
                        userInput.text = "Up Arrow";
                        break;
                    case KeyCode.DownArrow:
                        userInput.text = "";
                        userInput.text = "Down Arrow";
                        break;
                    case KeyCode.RightShift:
                        userInput.text = "";
                        userInput.text = "Right Shift";
                        break;
                        case KeyCode.LeftShift:
                        userInput.text = "";
                        userInput.text = "Left Shift";
                        break;
                    case KeyCode.LeftArrow:
                        userInput.text = "";
                        userInput.text = "Left Arrow";
                        break;
                    case KeyCode.RightArrow:
                        userInput.text = "";
                        userInput.text = "Right Arrow";
                        break;
                    case KeyCode.Backslash:
                        userInput.text = "";
                        userInput.text = "Backspace";
                        break;
                    case KeyCode.None:
                        userInput.text = "";
                        break;
                }
                if (!userInput.text.Equals("")) //TODO: need to change the if statement here to be set to equals and to s
                {
                    setKey(kcode, control); //bounds that function to that keycode
                    userInput.text = KeyBindings.checkKey(control).ToString(); //one huge line but it grabs the name of the control and sends it
                }
            }
        }

        //####another solution if this one above does not work with updating
        // string inputFromUser = userInput.text; 
        // if(!inputFromUser.Equals("")){
        //     bool confirm = confirmInput();
        //     if(confirm){
        //         setKey((KeyCode) Enum.Parse(typeof(KeyCode), inputFromUser), control);
        //         currentControl.GetComponent<Text>().text = KeyBindings.checkKey(control).ToString(); //one huge line but it grabs the name of the control and sends it
        //     }
        // }
    }

    //takes the keybinding script and sets the control to the value inputted
    private void setKey(KeyCode key, string nameOfControl)
    {
        KeyBindings.updateKey(key, nameOfControl);
    }

    private KeyCode getKeys(string keyCode)
    {
        return KeyBindings.checkKey(keyCode);
    }
}
