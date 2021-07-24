using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Generation : MonoBehaviour
{
    public List<enemyScriptable> enemies = new List<enemyScriptable>();

    //read the map and generate the enemies depending on what the map outputs
    [Server]
    private void Start()
    {
        foreach (enemyScriptable enemyData in enemies)
        {
            for (int x = 0; x < Map.width; x++)
            {
                for (int y = 0; y < Map.height; y++)
                {
                    if (enemyData.maxHeightRange > Noise_Generation.noiseMap[x, y] && enemyData.minHeightRange < Noise_Generation.noiseMap[x, y] && Random.Range(0f, 1f) < enemyData.chanceToGen)
                    {
                        GameObject enemy = Instantiate(enemyData.prefab, new Vector3(x, y, 0), Quaternion.identity); //Quaternoin.identity mean no roatation
                        NetworkServer.Spawn(enemy);
                    }
                }
            }
        }
    }
}
