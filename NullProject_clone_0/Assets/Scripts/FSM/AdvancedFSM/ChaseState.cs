using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    public ChaseState(){
        stateID = FSMStateID.Chasing;

        speed = 1f;
    }

    //reason for changing states
    public override void Reason(Transform player, Transform npc)
    {
        if(Vector2.Distance(npc.position, player.position) >= 5f){
            Debug.Log("Switching to the patrolling state");
            npc.GetComponent<NPCController>().SetTransition(Transition.LostPlayer); 
        }
    }

    //all actions that the ai will take in this state
    public override void Act(Transform player, Transform npc)
    {
        //all the chasing state does is chase the player only
        npc.position = Vector2.MoveTowards(npc.position, player.position, speed * Time.deltaTime);
    }
}
