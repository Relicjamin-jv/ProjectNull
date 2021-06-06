using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : AdvancedFSM
{
    protected override void Initialize()
    {
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player"); //finding the player object
        playerTransform = objPlayer.transform; //gets the x, y coordinates

        if(!playerTransform){
            Debug.Log("No player");
        }

        ConstructFSM();
    }

    protected override void FSMUpdate()
    {
        //nothing, can be used to update health and other things that arnt used in the the positioning of the player(phyiscs)
    }

    protected override void FSMFixedUpdate()
    {
        CurrentState.Reason(playerTransform, transform); //sends in the postion of the player and the npc
        CurrentState.Act(playerTransform, transform); //sends in the postion of the player and the npc
    }

    public void SetTransition(Transition t){
        PerformTransition(t);  
    }

    private void ConstructFSM(){
        //Get all the wonder points
        patrollList = GameObject.FindGameObjectsWithTag("Waypoint"); //get all the waypoints with the "Waypoint" tag associated with them
        Transform[] waypoints = new Transform[patrollList.Length]; //sets an array to be the size of the partroll list

        int i = 0;
        foreach(GameObject obj in patrollList){
            waypoints[i] = obj.transform;
            i++;
        }
        //npc will have a patrol state
        PatrolState patrol = new PatrolState(waypoints); 
        patrol.AddTransition(Transition.SawPlayer, FSMStateID.Chasing); //if saw player then transition into chasing the player

        //npc will have a chase state
        ChaseState chase = new ChaseState();
        chase.AddTransition(Transition.LostPlayer, FSMStateID.Patrolling);

        AddFSMState(patrol);
        AddFSMState(chase);
    }
}
