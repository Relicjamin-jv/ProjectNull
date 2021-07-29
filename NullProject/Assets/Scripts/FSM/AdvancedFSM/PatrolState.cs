using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PatrolState : FSMState
{
    public PatrolState(Transform[] wp){
        waypoints = wp;
        stateID = FSMStateID.Patrolling;

        speed = 5f;
    }

    public override void Reason(List<GameObject> player, Transform npc, GameObject enemy)
    {
        //check the distance from the player to the npc
        //when the distance is close enough then switch to chasing through the transitions
        foreach(GameObject obj in player){
            if(Vector2.Distance(npc.position, obj.transform.position) <= 5f){
                npc.GetComponent<NPCController>().SetTransition(Transition.SawPlayer);
                return;
            }
        } 
    }

    public override void Act(List<GameObject> player, Transform npc, GameObject enemy)
    {
        //find another transformation point if there is not reason

        if(Vector2.Distance(npc.position, destPos) < .1f){
            //Debug.Log("The NPC has reached the posistion");
            FindNextPoint(); //finding the next point
        }
        
        //Go forward
        if(destPos != Vector3.zero){
            npc.position = Vector2.MoveTowards(npc.position, destPos, speed * (Time.deltaTime/NPCController.playerGameObj.Count));
        }else{
            destPos = npc.position;
        }
    }

}
