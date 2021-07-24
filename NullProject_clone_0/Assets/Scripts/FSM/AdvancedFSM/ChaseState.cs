using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    private bool changeState = false;
    private int outOfRange = 0;
    private int closest = 0;

    public ChaseState()
    {
        stateID = FSMStateID.Chasing;

        speed = 1f;
    }

    //reason for changing states
    public override void Reason(List<GameObject> player, Transform npc)
    {
        for (int i = 0; i < player.Count; i++)
        {
            if (Vector2.Distance(npc.position, player[i].transform.position) >= 5f)
            {
                outOfRange++;
                if(outOfRange == player.Count){
                    changeState = true;
                }
            }

            if ((i + 1) == player.Count && changeState)
            {
                Debug.Log("Switching to the patrolling state");
                npc.GetComponent<NPCController>().SetTransition(Transition.LostPlayer);
            }
        }
        outOfRange = 0; //reset once the loop has completed
        changeState = false;
    }

    //all actions that the ai will take in this state
    public override void Act(List<GameObject> player, Transform npc)
    {
        //all the chasing state does is chase the player only
        for(int i = 0; i < player.Count - 1; i++){
            if(Vector2.Distance(npc.position, player[i].transform.position) < Vector2.Distance(npc.position, player[i+1].transform.position)){
                closest = i;
            }else{
                closest = i + 1;
            }
        }
        npc.position = Vector2.MoveTowards(npc.position, player[closest].transform.position, speed * Time.deltaTime); //move toward the closest player 
        closest = 0; //reset the index for the closest player 
    }
}
