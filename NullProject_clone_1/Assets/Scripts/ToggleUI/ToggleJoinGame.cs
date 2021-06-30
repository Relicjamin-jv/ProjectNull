using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleJoinGame : MonoBehaviour
{
    [SerializeField] public GameObject toogle;

   public void toggleJoinGame(){
       toogle.gameObject.SetActive(!toogle.activeSelf);
   }
}
