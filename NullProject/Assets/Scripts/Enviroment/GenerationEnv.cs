using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GenerationEnv : MonoBehaviour
{
    public List<ScritableEnv> EnviromentObj = new List<ScritableEnv>();

    //read the map and generate the enemies depending on what the map outputs
    [Server]
    private void Start()
    {
        foreach (ScritableEnv envData in EnviromentObj)
        {
            for (int x = 0; x < Map.width - 1; x++)
            {
                for (int y = 0; y < Map.height - 1; y++)
                {
                    if (Noise_Generation.noiseMap != null)
                    {
                        if (envData.maxHeightRange > Noise_Generation.noiseMap[x, y] && envData.minHeightRange < Noise_Generation.noiseMap[x, y] && Random.Range(0f, 1f) < envData.chanceToGen)
                        {
                            GameObject EnvObj = Instantiate(envData.sprite, new Vector3(x, y, 0), Quaternion.identity); //Quaternoin.identity mean no roatation
                            NetworkServer.Spawn(EnvObj);
                        }
                    }
                }
            }
        }
    }
}
