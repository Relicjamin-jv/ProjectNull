using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;

public class PanAndZoomBehavior : NetworkBehaviour
{
    private bool _isFocusing; //whether the focusing is still happening or not
    [Header("Pan Speed")]
    public float panSpeed = 5f; //the speed at which it pans
    public float panSpeedFocus = 100f;
    [Header("Zoom Options")]
    public float zoomSpeed = 4f;
    public float zoomMax = 40f;
    public float zoomMin = 5f;
    [SerializeField]
    private Collider2D bounds;
    private Vector3 player;

    private CinemachineVirtualCamera virtualCamera;
    private Transform camTrans;

    //references to the camera componets
    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        camTrans = virtualCamera.VirtualCameraGameObject.transform;
    }

    private void Update()
    {
        // Vector2 mouse = Input.mousePosition; //gets the mouse position
        // float mouseScrollWheel = Input.mouseScrollDelta.y; //returns 0 if the scroll wheel is not being used, forward -1 back 1;
        // float x = mouse.x;
        // float y = mouse.y;
        // if(x != 0 || y != 0){
        //     pan(x, y);
        // }
        // float z = mouseScrollWheel; 
        // if(z != 0){
        //     _isFocusing = false;
        //     zoomScreen(z);
        // }

        // if(InputManager.instance.KeyDown("Focus")){
        //     _isFocusing = true;
        // }
        focusOnPlayer();
        if (_isFocusing)
        {
            // focusOnPlayer();
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

    public void focusOnPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for(int i = 0; i < players.Length; i++){
            if(players[i].GetComponent<NetworkIdentity>().hasAuthority){
                player = players[i].transform.position;
            }
        }

        float fov = virtualCamera.m_Lens.OrthographicSize; //gets the feild of view var from the member variable from the virtual camera
        Vector3 _targetPostion = player;
        _targetPostion.z = camTrans.position.z; //keep the z the same for the camera
        while (camTrans.position != _targetPostion)
        {
            camTrans.position = Vector3.MoveTowards(this.transform.position, _targetPostion, panSpeedFocus * Time.deltaTime); //moves towards the player object
        }
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(fov, zoomMin, zoomSpeed * Time.deltaTime); //moves the feild of view towards the min. scroll value

    }


    // public void zoomScreen(float param)
    // {
    //     float fov = virtualCamera.m_Lens.OrthographicSize; //gets the feild of view var from the member variable from the virtual camera
    //     float target = Mathf.Clamp(fov + (-param), zoomMin, zoomMax); //clamps the value between these two values so the param doesn't go below or higher
    //     virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime); //moves the feild of view towards the user scoll value
    // }

    // public Vector2 PanDirection(float x, float y)
    // {
    //     Vector2 direction = Vector2.zero;

    //     if (y >= Screen.height * .95f)
    //     {
    //         _isFocusing = false;
    //         direction.y += 1; //move in that direction
    //     }
    //     else if (y <= Screen.height * .05f)
    //     {
    //         _isFocusing = false;
    //         direction.y -= 1; //move in that direction
    //     }
    //     if (x >= Screen.width * .95f)
    //     {
    //         _isFocusing = false;
    //         direction.x += 1; //move in that direction
    //     }
    //     else if (x <= Screen.width * .05f)
    //     {
    //         _isFocusing = false;
    //         direction.x -= 1; //move in that direction
    //     }
    //     return direction; //returns the direction of the way the user wants to pan
    // }

    // //under getaxisvalue func. from cinemachine it takes in float and returns only the x and y
    // public void pan(float x, float y)
    // {
    //     Vector2 direction = PanDirection(x, y); //calls the pan direction and get the direction of the mouse and where it's going
    //     Vector3 targetPosition = camTrans.position + (Vector3)direction * panSpeed;
    //     targetPosition.x = Mathf.Clamp(targetPosition.x, bounds.bounds.min.x, bounds.bounds.max.x);
    //     targetPosition.y = Mathf.Clamp(targetPosition.y, bounds.bounds.min.y, bounds.bounds.max.y);
    //     camTrans.position = Vector3.Lerp(camTrans.position, targetPosition, Time.deltaTime); //lineraly interpolate for a smooth transiton of where you want it to go
    // }


}
