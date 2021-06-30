using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    //Player Transformation
    protected Transform playerTransform;

    //Next Way point for the player
    protected Vector2 destPos;

    //List of all partrolling routes
    protected GameObject[] patrollList;

    protected virtual void Initialize(){} //Virutal is the parent method that will be overriden in the child classes
    protected virtual void FSMUpdate(){}
    protected virtual void FSMFixedUpdate(){}

    private void Start() {
        Initialize();
    }

    private void Update() {
        FSMUpdate();
    }

    private void FixedUpdate() {
        FSMFixedUpdate();
    }

 }
