using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;

public class NetworkGame : NetworkBehaviour
{
    public string DisplayName = "Loading...";

    private NetworkManagerNull room;

    private  NetworkManagerNull Room{ //persist between scenes automatically cast its so we only need to call room to get the network manager
        get{
            if(room != null){
                return room;
            }
            return room = NetworkManager.singleton as NetworkManagerNull;
        }
    }

    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject); 
        Room.gamePlayers.Add(this); //when the client or the host runs this it will add itself to the list in the Network Manager
    }

    public override void OnStopClient() //when the client disconnects it will remove itself from the list on the server
    {
        Room.gamePlayers.Remove(this);
    }

    public void SetDisplayName(string name){
        this.DisplayName =  name;
    }
   
}