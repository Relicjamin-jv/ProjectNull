using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : FSMState
{

    public DeadState()
    {
        stateID = FSMStateID.Dead;

        speed = 0f;
    }

    //reason for changing states
    public override void Reason(List<GameObject> player, Transform npc, GameObject enemy)
    {
        //there are none the object is dead
    }

    //all actions that the ai will take in this state
    public override void Act(List<GameObject> player, Transform npc, GameObject enemy)
    {
        Combat.enemies.Remove(enemy.GetComponent<NPCController>());
        Destroy.Destroy(enemy);
    }
}
