using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class CombatLogic : NetworkBehaviour
{
    public NetworkGame player;
    public NPCController enemy;

    private void Update() {
        if(enemy.health <= 0){
            player.state = battleState.NotInBattle;
        }
    }
    
    [Command]
    public void CMDAttackEnemy(){
        enemy.health = 0;
    }
}
