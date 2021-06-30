using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Map : NetworkBehaviour
{   
    [Client]
    void Start()
    {
        GenerateMap();
        this.gameObject.SetActive(true);
    }

    // Array to store all of the Biome Presets
    public BiomePreset[] biomes;
    public GameObject tilePrefab;

    // Array to store Map Dimensions
    [Header("Dimensions")]
    public const int width = 200;
    public const int height = 200;

    [SyncVar]
    public float scale = 1.0f;

    [SyncVar]
    public Vector2 offset;

    [Header("Height Map")]
    [SyncVar]
    public float seed = 69;

    public Wave[] heightWaves;
    public float[,] heightMap;

    void GenerateMap ()
    {
        // height map
        heightMap = Noise_Generation.Generate(width, height, scale, heightWaves, offset, seed);

        for(int x = 0; x < width; ++x)
        {
            for(int y = 0; y < height; ++y)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity); //Quaternoin.identity mean no roatation
                tile.GetComponent<SpriteRenderer>().sprite = GetBiome(heightMap[x, y]).GetTileSprite();
            }
        }
    }

    BiomePreset GetBiome (float height)
    {
        List<BiomeTempData> biomeTemp = new List<BiomeTempData>();

        foreach(BiomePreset biome in biomes)
        {
            if(biome.MatchCondition(height))
            {
                biomeTemp.Add(new BiomeTempData(biome));                
            }
        }

        float curVal = 0.0f;
        BiomePreset biomeToReturn = default;

        foreach(BiomeTempData biome in biomeTemp)
        {
            if(biomeToReturn == null)
            {
                biomeToReturn = biome.biome;
                curVal = biome.GetDiffValue(height);
            }
            else
            {
                if(biome.GetDiffValue(height) < curVal)
                {
                    biomeToReturn = biome.biome;
                    curVal = biome.GetDiffValue(height);
                }
            }
        }

        if(biomeToReturn == null)
            biomeToReturn = biomes[0];

        return biomeToReturn;
    }
}

public class BiomeTempData
{
    public BiomePreset biome;

    public BiomeTempData (BiomePreset preset)
    {
        biome = preset;
    }
        
    public float GetDiffValue (float height)
    {
        return (height - biome.minHeight);
    }
}
