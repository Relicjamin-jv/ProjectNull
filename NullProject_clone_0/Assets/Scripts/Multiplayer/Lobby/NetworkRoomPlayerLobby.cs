using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;

public class NetworkRoomPlayerLobby : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject lobbyUI;
    [SerializeField] private TMP_Text[] playerNameArray = new TMP_Text[4];
    [SerializeField] private TMP_Text[] playerReadyArray = new TMP_Text[4];
    [SerializeField] private Button startGameButton;

    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string DisplayName = "Loading...";
    [SyncVar(hook = nameof(HandleReadyStatusChange))]
    public bool IsReady = false;

    private bool isLeader;

    public bool IsLeader{
        set{
            isLeader = value;
            startGameButton.gameObject.SetActive(value);
        }
    }

    private NetworkManagerNull room;

    private  NetworkManagerNull Room{ //persist between scenes automatically cast its so we only need to call room to get the network manager
        get{
            if(room != null){
                return room;
            }
            return room = NetworkManager.singleton as NetworkManagerNull;
        }
    }

    public override void OnStartAuthority()
    {
        CmdSetDisplayName(PlayerNameInput.DisplayName); //function that is called by clients in order to run a function on the server
        
        lobbyUI.SetActive(true);
    }

    public override void OnStartClient()
    {
        Room.roomPlayers.Add(this); //when the client or the host runs this it will add itself to the list in the Network Manager
        
        UpdateDisplay();
    }

    public override void OnStopClient() //when the client disconnects it will remove itself from the list on the server
    {
        Room.roomPlayers.Remove(this);

        UpdateDisplay();
    }

    public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();
    public void HandleReadyStatusChange(bool oldValue, bool newValue) => UpdateDisplay();

    private void UpdateDisplay(){
        Debug.Log("Updating UI");
        if(!isLocalPlayer){ //if not the local player doing the change then we need to find our object and update that object
            foreach(var player in Room.roomPlayers){
                if(player.isLocalPlayer){
                    player.UpdateDisplay();
                    break;
                }
            }
            return;
        }

        for(int i = 0; i < playerNameArray.Length; i++){ //clears everything
            playerNameArray[i].text = "Wait For Player...";
            playerReadyArray[i].text = string.Empty;
        }

        for(int i = 0; i < Room.roomPlayers.Count; i++){ //resets everything
            playerNameArray[i].text = Room.roomPlayers[i].DisplayName;
            playerReadyArray[i].text = Room.roomPlayers[i].IsReady ?
                "<color=green>Ready</color>" : "<color=red>Not Ready</color>";
        }
    }

    public void HandleReadyToStart(bool ready){
        if(!isLeader) {return;}

        startGameButton.interactable = ready;
    }

    [Command]
    public void CmdSetDisplayName(string displayName){
        DisplayName = displayName;
    }

    [Command]
    public void CmdReadyUp(){
        IsReady = !IsReady; //toggle

        Room.NoitfyPlayersofState();
    }

    [Command]
    public void CmdStartGame(){
        if(Room.roomPlayers[0].connectionToClient != connectionToClient) {return;}

        room.StartGame();
    }

}
