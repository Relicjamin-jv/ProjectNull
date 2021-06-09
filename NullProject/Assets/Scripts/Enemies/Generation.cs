using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    //the scriptable enemy
    public enemyScriptable enemyData;


    //read the map and generate the enemies depending on what the map outputs
    private void Start()
    {
        for (int x = 0; x < Map.width; x++)
        {
            for (int y = 0; y < Map.height; y++)
            {
                if(enemyData.maxHeightRange > Noise_Generation.noiseMap[x, y] && enemyData.minHeightRange < Noise_Generation.noiseMap[x,y] && Random.Range(0f, 1f) < enemyData.chanceToGen){
                    GameObject enemy = Instantiate(enemyData.prefab, new Vector3(x, y, 0), Quaternion.identity); //Quaternoin.identity mean no roatation
                }
            }
        }
    }
}
