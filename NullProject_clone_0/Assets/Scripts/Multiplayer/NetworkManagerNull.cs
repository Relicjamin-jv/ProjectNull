using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManagerNull : NetworkManager
{
    [SerializeField] private int minPlayers = 2;
    [Scene] [SerializeField] private string menuScene;

    [Header("Room")]
    [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

    [Header("Game")]
    [SerializeField] private NetworkGame gamePlayerPrefab;
    [SerializeField] private GameObject playerSpawnSystem;
    [SerializeField] private GameObject enemySpawnSystem;
    [SerializeField] private GameObject envSpawnSystem;
    [SerializeField] private GameObject combatSystem;

    public static NetworkManagerNull instance;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;
    public static event Action<NetworkConnection> OnServerReadied; //need too wait for everyone to connect

    public List<NetworkRoomPlayerLobby> roomPlayers { get; } = new List<NetworkRoomPlayerLobby>(); //room player data
    public List<NetworkGame> gamePlayers { get; } = new List<NetworkGame>(); //game player data


    public override void OnStartServer() => spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();

    public override void OnStartClient()
    {
        var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");

        foreach (var prefab in spawnablePrefabs)
        {
            NetworkClient.RegisterPrefab(prefab);
        }
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        OnClientConnected?.Invoke();
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);

        OnClientDisconnected?.Invoke();
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        if (numPlayers >= maxConnections)
        {
            conn.Disconnect();
            return;
        }

        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            conn.Disconnect();
            return;
        }
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            bool isLeader = roomPlayers.Count == 0; //if there is no one in the room server then the first one to join is considered the leader

            NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab); //instatiate the player

            roomPlayerInstance.IsLeader = isLeader; 

            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject); //set that gameobject that was made on the server to go ahead and set the connection up for that specific obj.
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn) //server removing from the list
    {
        if (conn.identity != null)
        {
            var player = conn.identity.GetComponent<NetworkRoomPlayerLobby>();
            roomPlayers.Remove(player); //removes the player from the lobby
            NoitfyPlayersofState(); //notifies the player whether the ready state has been made or not
        }
        base.OnServerDisconnect(conn);
    }

    public override void OnStopServer()
    {
        roomPlayers.Clear(); //clears the list so when a client or host goes again it doesnt keep the data from before hand
    }

    public void NoitfyPlayersofState(){
        foreach(var player in roomPlayers){
            player.HandleReadyToStart(IsReadyToStart());
        }
    }

    public bool IsReadyToStart(){
        if(numPlayers < minPlayers) {return false;} //cant start the game unless we have enough players in order to do so

        foreach(var player in roomPlayers){ //all players need to be ready in order to start the game
            if(!player.IsReady){
                return false;
            }
        }

        return true;
    }
    
    public bool IsReadyForNextTurn(){
        foreach(var player in gamePlayers){ //all players need to be ready in order to start the game
            if(!player.isReadyForNextTurn){
                return false;
            }
        }
        foreach(var player in gamePlayers){
            player.reset();
        }
        return true;
    }

    public void NextTurnCheck(){
        if(IsReadyForNextTurn()){
            foreach(var player in gamePlayers){
                player.setIsReadyForNextTurn();
            }
        }
    }

    public void StartGame(){
        if(SceneManager.GetActiveScene().name == "Main Menu"){
            if(!IsReadyToStart()) {return;}

            ServerChangeScene("Main");
        }
    }


    public override void ServerChangeScene(string newSceneName)
    {
        if(SceneManager.GetActiveScene().name == "Main Menu" && newSceneName.StartsWith("Main")){
            for(int i = roomPlayers.Count - 1; i >= 0; i--){
                var conn = roomPlayers[i].connectionToClient;
                var gamePlayerInstance = Instantiate(gamePlayerPrefab);
                gamePlayerInstance.SetDisplayName(roomPlayers[i].DisplayName);

                NetworkServer.Destroy(conn.identity.gameObject);

                NetworkServer.ReplacePlayerForConnection(conn, gamePlayerInstance.gameObject, true);
            }
        }

        base.ServerChangeScene(newSceneName);
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        if(sceneName.StartsWith("Main")){
            // GameObject playerSpawnSystemInstance = Instantiate(playerSpawnSystem);
            // NetworkServer.Spawn(playerSpawnSystemInstance); //server owns the spawn system
            GameObject enemySpawnSystemInstance = Instantiate(enemySpawnSystem);
            NetworkServer.Spawn(enemySpawnSystemInstance);
            GameObject enviromentSpawnSystemInstance = Instantiate(envSpawnSystem);
            NetworkServer.Spawn(enviromentSpawnSystemInstance);
            GameObject spawnCombatSystem = Instantiate(combatSystem);
            NetworkServer.Spawn(spawnCombatSystem);
        }
    }

    public override void OnServerReady(NetworkConnection conn)
    {
        base.OnServerReady(conn);

        OnServerReadied?.Invoke(conn);
    }
}
