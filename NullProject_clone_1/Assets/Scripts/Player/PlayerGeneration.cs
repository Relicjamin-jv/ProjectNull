using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneration : MonoBehaviour
{
    int tileToGenerateX;
    int tileToGenerateY;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++){
            tileToGenerateX = Random.Range(1, 200); //what x tile to be generated on
            tileToGenerateY = Random.Range(1, 200); //what y tile to be generated on
            Vector3 spawnPoint = new Vector3(tileToGenerateX, tileToGenerateY);
            PlayerSpawn.addSpawnPoint(spawnPoint);
        }
        
    }

}
