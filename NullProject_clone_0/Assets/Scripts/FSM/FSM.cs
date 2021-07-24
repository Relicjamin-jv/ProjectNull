using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FSM : NetworkBehaviour
{
    //Player Transformation
    protected List<Transform> playerTransform = new List<Transform>();

    //Next Way point for the player
    protected Vector2 destPos;

    //List of all partrolling routes
    protected GameObject[] patrollList;

    protected virtual void Initialize(){} //Virutal is the parent method that will be overriden in the child classes
    protected virtual void FSMUpdate(){}
    protected virtual void FSMFixedUpdate(){}


    private void Start() {
        if(isServer){
            Initialize();
        }
    }

    
    private void Update() {
        if(isServer){
            FSMUpdate();
        }
    }

    
    private void FixedUpdate() {
        if(isServer){
            FSMFixedUpdate();
        }
        
    }

 }
