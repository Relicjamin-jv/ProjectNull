using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : FSMState
{
    public AttackState()
    {
        stateID = FSMStateID.Attacking;

        speed = 0f;
    }

    //reason for changing states
    public override void Reason(List<GameObject> player, Transform npc, GameObject enemy)
    {
        if(npc.GetComponent<NPCController>().health < 1){
            npc.GetComponent<NPCController>().SetTransition(Transition.NoHealth);
        }
    }

    //all actions that the ai will take in this state
    public override void Act(List<GameObject> player, Transform npc, GameObject enemy)
    {
        player[0].GetComponent<NetworkGame>().health -= 1;
    }
}
                