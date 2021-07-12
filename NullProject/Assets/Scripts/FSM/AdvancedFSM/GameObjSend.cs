using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameObjSend : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        sendToServerLocal();
    }

    [Command]
    void sendToServerLocal(){
        NPCController.playerGameObj.Add(this.gameObject);
    }
}
