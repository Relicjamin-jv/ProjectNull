using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScreenToggle : MonoBehaviour
{
    public GameObject characterToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.instance.KeyDown("Character Screen")){ //toggles the character UI elements with what ever the character Screen is attached to
            characterToggle.gameObject.SetActive(!characterToggle.activeSelf);
        }
    }
}
