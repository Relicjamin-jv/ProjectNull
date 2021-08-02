using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Biome Preset", menuName = "New Biome Preset")]
public class BiomePreset : ScriptableObject
{
    // Biome properties
    public Sprite[] tiles;
    public float minHeight;

    // Selects a random sprite from the preset tiles
    // We can later change this to only select tile that fit together
    public Sprite GetTileSprite ()
    {
        return tiles[Random.Range(0, tiles.Length)];
    }

    // Checks whether conditions match
    public bool MatchCondition (float height)
    {
        return height >= minHeight;
    }
}
