using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSpawn : NetworkBehaviour
{
    [SerializeField]
    private GameObject playerPrefab = null;

    private static List<Transform> spawnPoints = new List<Transform>(); //all the points the player can spawn on the map

    private int nextIndex = 0; //where it starts to spawn the player on the map

    public static void addSpawnPoint(Transform transform){
        spawnPoints.Add(transform);
    }

    public static void removeSpawnPoint(Transform transform){
        spawnPoints.Remove(transform);
    }

    public override void OnStartServer(){
        
    }
}
