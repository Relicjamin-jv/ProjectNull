using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mirror;

public class GUIControlTurns : NetworkBehaviour
{
    Text text;

    #region singleton
    public static GUIControlTurns instance;

    private void Awake() {
        if(instance != null){
            Debug.LogError("There is more than one instance of GUIControlTurns");;
        }
        instance = this;
    }
    #endregion
    [SyncVar]
    public int turn = 0;

    private void Start() {
        text = this.GetComponent<Text>();
    }

    private void Update() {
        Debug.Log(turn);
        text.text = "Turns: " + turn;
    }
}
