using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Combat : NetworkBehaviour
{
    public static List<NPCController> enemies = new List<NPCController>();
    
    private NetworkManagerNull room;

    private NetworkManagerNull Room
    { //persist between scenes automatically cast its so we only need to call room to get the network manager
        get
        {
            if (room != null)
            {
                return room;
            }
            return room = NetworkManager.singleton as NetworkManagerNull;
        }
    }


    [Server]
    void Update()
    {
        foreach(var player in Room.gamePlayers){
            foreach(NPCController enemy in enemies){
                if(Vector2.Distance(player.transform.position, enemy.transform.position) < 2f){
                    player.state = battleState.InBattle;
                    CombatLogic gPlayer = player.GetComponentInChildren<CombatLogic>();
                    if(gPlayer == null) return;
                    gPlayer.player = player;
                    gPlayer.enemy = enemy;
                }
            }
        }
    }
}
