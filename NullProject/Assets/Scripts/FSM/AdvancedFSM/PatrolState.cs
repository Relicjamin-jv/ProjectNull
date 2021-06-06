using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    public PatrolState(Transform[] wp){
        waypoints = wp;
        stateID = FSMStateID.Patrolling;

        speed = 5f;
    }

    public override void Reason(Transform player, Transform npc)
    {
        //check the distance from the player to the npc
        //when the distance is close enough then switch to chasing through the transitions 
        if(Vector2.Distance(npc.position, player.position) <= 5f){
            Debug.Log("Switching to the chasing state");
            npc.GetComponent<NPCController>().SetTransition(Transition.SawPlayer);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        //find another transformation point if there is not reason

        if(Vector2.Distance(npc.position, destPos) < .1f){
            //Debug.Log("The NPC has reached the posistion");
            FindNextPoint(); //finding the next point
        }

        //Go forward 
        npc.position = Vector2.MoveTowards(npc.position, destPos, speed * Time.deltaTime);
    }

}
