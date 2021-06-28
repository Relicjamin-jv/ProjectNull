using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField nameInputFeild = null;
    [SerializeField] private Button continueButton = null;

    public static string DisplayName {get; private set;} //can get it but only set it internally

    //private const string playerPrefsNameKey = "PlayerName"; //the key for saving and loading it from player prefs <- need to set up another class that deals with looking up with keys from the player to auto input the feild

    private void Update() {
        setUpInput();
    }

    private void setUpInput(){
        SetPlayerName(nameInputFeild.text);
    }

    public void SetPlayerName(string name){
        continueButton.interactable = !string.IsNullOrEmpty(name); //if there is something them makes the button interactable
        DisplayName = name;
    }

    public void disablePanel(){
        this.gameObject.SetActive(false);
    }
}
