using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NetworkGame : NetworkBehaviour
{
    public string DisplayName = "Loading...";
    public static bool isDragging = false;

    [SyncVar]
    public int health = 100;
    [SyncVar]
    public float stamina = 100;

    [SerializeField] private GameObject interactionUI;
    [SerializeField] private Slider stamSlider;

    [SyncVar]
    public bool isReadyForNextTurn = false;

    private NetworkManagerNull room;

    private NetworkManagerNull Room
    { //persist between scenes automatically cast its so we only need to call room to get the network manager
        get
        {
            if (room != null)
            {
                return room;
            }
            return room = NetworkManager.singleton as NetworkManagerNull;
        }
    }

    public override void OnStartAuthority()
    {
        interactionUI.SetActive(true);
    }

    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
        Room.gamePlayers.Add(this); //when the client or the host runs this it will add itself to the list in the Network Manager
        sendToServerLocalAdd();
    }

    public override void OnStopClient() //when the client disconnects it will remove itself from the list on the server
    {
        Room.gamePlayers.Remove(this);
        sendToServerLocalRemove();
    }

    public void SetDisplayName(string name)
    {
        this.DisplayName = name;
    }

    public void readyforNextTurn()
    {
        if (hasAuthority)
        {
            CmdReadyForNextTurn();
        }
    }

    [Command]
    public void CmdReadyForNextTurn()
    {
        isReadyForNextTurn = !isReadyForNextTurn; //toggle 

        Room.NextTurnCheck(); //checks if it can go to the next turn or not
    }

    [Command]
    void sendToServerLocalRemove(){
        NPCController.playerGameObj.Add(this.gameObject);
    }

    [Command]
    void sendToServerLocalAdd(){
        NPCController.playerGameObj.Add(this.gameObject);
    }

    [Server]
    public void setIsReadyForNextTurn()
    {
        isReadyForNextTurn = false;
    }


    /*
    ###MOVEMENT LOGIC###
    */
    public float speed = 4f;
    private Vector3 _targetPostion;
    private bool isMoving;

    //random location on map
    private void Start() {
        this.transform.position = new Vector3(Random.Range(1, 199), Random.Range(1, 199), 0);
    }

    public void reset(){
        stamina = 100f;
        this.stamSlider.value = 100;
    }

     void SetTargetPosition()
    {
        _targetPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetPostion.z = transform.position.z;

        isMoving = true;
    }

    void move()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, _targetPostion, speed * Time.deltaTime);
        decreaseStamina();
        if (transform.position == _targetPostion)
        {
            isMoving = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stamSlider.value = (stamina/100f) * 100;
        if (hasAuthority)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

                if(hit && !EventSystem.current.IsPointerOverGameObject() && !isDragging){
                    Debug.Log(isDragging);
                    SetTargetPosition();
                }
            }

            if (isMoving && stamina > 0)
            {
                move();
            }else{
                isMoving= false;
            }
        }
    }

    [Command]
    private void decreaseStamina(){
        stamina -= .2f;
    }
}
