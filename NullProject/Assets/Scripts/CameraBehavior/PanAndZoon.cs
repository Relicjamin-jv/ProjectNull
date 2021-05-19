using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PanAndZoon : MonoBehaviour
{
    [Header("PanSpeed")]
    public float panSpeed = 5f; //the speed at which it pans

    private CinemachineVirtualCamera virtualCamera;
    private Transform camTrans;

    //references to the camera componets
    private void Awake() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        camTrans = virtualCamera.VirtualCameraGameObject.transform;
    }

    private void Update() {
        Vector2 mouse = Input.mousePosition; //gets the mouse position
        float x = mouse.x;
        float y = mouse.y;
        if(x != 0 || y != 0){
            pan(x, y);
        }

        //*******IGNORE******** used for the input package system in unity, I'm making the decision for at least now to not use it 
        // float x = inputProvider.GetAxisValue(0); //from the input provider and recieves the x value from the postion of the mouse
        // float y = inputProvider.GetAxisValue(1); //from the input provider and recieves the y value from the postion of the mouse
        // float z = inputProvider.GetAxisValue(2); //from the input provider and recieves the z value from the postion of the mouse
        // if(x != 0 || y != 0) // if there is a value from the mouse then update(pan(x, y))
        // {
        //     pan(x, y);
        // }
    }

    public Vector2 PanDirection(float x, float y){
        Vector2 direction = Vector2.zero;

        if(y >= Screen.height * .95f){
            direction.y += 1; //move in that direction
        }
        else if(y <= Screen.height * .05f){
            direction.y -= 1; //move in that direction
        }
        if(x >= Screen.width * .95f){
            direction.x += 1; //move in that direction
        }
        else if(x <= Screen.width * .05f){
            direction.x -= 1; //move in that direction
        }
        return direction; //returns the direction of the way the user wants to pan
    }

    //under getaxisvalue func. from cinemachine it takes in float and returns only the x and y
    public void pan(float x, float y){
        Vector2 direction = PanDirection(x, y); //calls the pan direction and get the direction of the mouse and where it's going
        camTrans.position = Vector3.Lerp(camTrans.position,camTrans.position + (Vector3)direction * panSpeed, Time.deltaTime); //lineraly interpolate for a smooth transiton of where you want it to go
    }


}
