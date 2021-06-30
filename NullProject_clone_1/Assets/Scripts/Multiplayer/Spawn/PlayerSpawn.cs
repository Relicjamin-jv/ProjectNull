using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;

public class PlayerSpawn : NetworkBehaviour
{
    [SerializeField]
    private GameObject playerPrefab = null;

    private static List<Vector3> spawnPoints = new List<Vector3>(); //all the points the player can spawn on the map

    private int nextIndex = 0; //where it starts to spawn the player on the map

    public static void addSpawnPoint(Vector3 transform){
        spawnPoints.Add(transform);
    }

    public static void removeSpawnPoint(Vector3 transform){
        spawnPoints.Remove(transform);
    }

    public override void OnStartServer(){
        NetworkManagerNull.OnServerReadied += SpawnPlayer;
    }

    [ServerCallback]
    private void OnDestroy() {
        NetworkManagerNull.OnServerReadied -= SpawnPlayer;
    }

    [Server]
    public void SpawnPlayer(NetworkConnection conn){
        Vector3 spawnPoint = spawnPoints.ElementAtOrDefault(nextIndex); //reiterates the list if we go out of index

        if(spawnPoint == null){
            Debug.LogError("Missing a spawn point");
            return;
        }

        GameObject playerInstance = Instantiate(playerPrefab, spawnPoints[nextIndex], Quaternion.identity);
        NetworkServer.Spawn(playerInstance, conn); //with this the player actally gains auth over it

        nextIndex++;
    }
}
