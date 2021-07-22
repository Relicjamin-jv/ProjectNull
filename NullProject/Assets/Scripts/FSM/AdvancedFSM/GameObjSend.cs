using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameObjSend : NetworkBehaviour
{
    [Command]
    void sendToServerLocal(){
        NPCController.playerGameObj.Add(this.gameObject);
    }
}
