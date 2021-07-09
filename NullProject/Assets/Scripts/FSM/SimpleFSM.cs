// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SimpleFSM : FSM
// {
//     public enum FSMState
//     {
//         None,
//         Partrol,
//         Chase,
//         Attack,
//         //Dead
//     }

//     public FSMState curState; //what state are we in now

//     public float curSpeed; // the speed of the enemy player

//     //private int health; //the health of the enemy

//     //private bool dead; //dead or not

//     new private Rigidbody2D rigidbody;

//     protected override void Initialize()
//     {
//         curState = FSMState.Partrol;
//         curSpeed = 4f;
//         //dead = false;
//         //health = 100;
//         patrollList = GameObject.FindGameObjectsWithTag("Waypoint");

//         destPos = findNextPoint(); //find next partrol point

//         GameObject player = GameObject.FindGameObjectWithTag("Player");

//         rigidbody = GetComponent<Rigidbody2D>(); //get the ridgid body

//         playerTransform = player.transform; //get the postion of the player to calculate whether it should change or not to the chasing state
        
//         if(!playerTransform){
//             Debug.Log("Player doesn't exist");
//         }
//     }

//     //next point to travel to 
//     protected Vector2 findNextPoint(){
//         int randomIndex = Random.Range(0, (patrollList.Length));
//         Vector2 nextPatrol = patrollList[randomIndex].transform.position;
//         return nextPatrol;
//     }

//     protected override void FSMUpdate()
//     {
//         switch(curState){
//             case FSMState.Partrol: UpdatePartrolState(); break;
//             case FSMState.Chase: UpdateChaseState(); break;
//             // case FSMState.Attack: UpdateAttackState(); break;
//             // case FSMState.Dead: UpdateDeadState(); break;
//         }
//         // if(health <= 0){
//         //     curState = FSMState.Dead; //the enemy has no health
//         // }
//     }

//     protected void UpdatePartrolState(){
//         //find another posistion if the current patrol has been reached by the AI
//         if(Vector2.Distance(transform.position, destPos) < .1f){
//             Debug.Log("The Ai has reached the destination");
//             destPos = findNextPoint();
//         }else if(Vector2.Distance(transform.position, playerTransform.position) <= 5f){
//             Debug.Log("The Ai has detected the player");
//             curState = FSMState.Chase;
//         }

//         //Move
//         transform.position = Vector2.MoveTowards(transform.position, destPos, curSpeed * Time.deltaTime);
//     }

//     protected void UpdateChaseState(){
//         destPos = playerTransform.position; //set the destination to the player position

//         float dist = Vector2.Distance(transform.position, playerTransform.position); //the distance between the player and the AI

//         if(dist <= .5f){
//             Debug.Log("Ai close enough to attack the player");
//         }else if(dist > 2f){
//             Debug.Log("Lost the player");
//             curState = FSMState.Partrol; //lost the player
//         }

//         //move 
//         transform.position = Vector2.MoveTowards(transform.position, destPos, curSpeed * Time.deltaTime);

//     }   
// }
