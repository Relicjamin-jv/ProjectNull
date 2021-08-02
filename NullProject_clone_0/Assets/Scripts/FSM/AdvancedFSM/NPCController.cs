using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NPCController : AdvancedFSM
{   
    [SyncVar]
    public int health = 100;

    public GameObject waypointObj;
    public static List<GameObject> playerGameObj = new List<GameObject>(); 

    protected override void Initialize()
    {
        Combat.enemies.Add(this);
        ConstructFSM();
    }

    protected override void FSMUpdate()
    {
        //nothing, can be used to update health and other things that arnt used in the the positioning of the player(phyiscs)
    }

    protected override void FSMFixedUpdate()
    {
        CurrentState.Reason(playerGameObj, this.transform, this.gameObject); //sends in the postion of the player and the npc
        CurrentState.Act(playerGameObj, this.transform, this.gameObject); //sends in the postion of the player and the npc
    }

    public void SetTransition(Transition t){
        PerformTransition(t);  
    }

    private void ConstructFSM(){
        //Get all the wonder points
        Transform[] waypoints = new Transform[5]; //sets an array to be the size of the partroll list
        for(int k = 0; k < waypoints.Length; k++){
            GameObject waypoint = Instantiate(waypointObj, new Vector3(this.transform.position.x + Random.Range(-10f, 10f), this.transform.position.y + Random.Range(-10f, 10f), 0), Quaternion.identity); //Quaternoin.identity mean no roatation
            waypoints[k] = waypoint.transform;
        }


        //npc will have a patrol state
        PatrolState patrol = new PatrolState(waypoints); 
        patrol.AddTransition(Transition.SawPlayer, FSMStateID.Chasing); //if saw player then transition into chasing the player
        AddFSMState(patrol);
        // npc will have a chase state
        ChaseState chase = new ChaseState();
        chase.AddTransition(Transition.LostPlayer, FSMStateID.Patrolling);
        chase.AddTransition(Transition.ReachPlayer, FSMStateID.Attacking);
        AddFSMState(chase);
        //npc will have an attack state
        AttackState attack = new AttackState();
        attack.AddTransition(Transition.LostPlayer, FSMStateID.Patrolling);
        attack.AddTransition(Transition.NoHealth, FSMStateID.Dead);
        AddFSMState(attack);
        DeadState dead = new DeadState();
        AddFSMState(dead);
        
    }
}
