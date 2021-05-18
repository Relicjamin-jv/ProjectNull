using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise_Generation : MonoBehaviour
{

    //
    // Generates the Noise Map          Width       Height      Scale       Waves               Offeset
    public static float[,] Generate (int width, int height, float scale, Wave[] waves, Vector2 offset)
    {
        float[,] noiseMap = new float[width, height];
        
        for(int x = 0; x < width; ++x)
        {
            for(int y = 0; y < height; ++y)
            {   
                // Get sample positions for the X and Y coords on the map
                float samplePosX = (float)x * scale + offset.x;
                float samplePosY = (float)y * scale + offset.y;

                float normalization = 0.0f;
                
                // Loop through the waves
                foreach(Wave wave in waves)
                {   
                    // Sample the perlin noise with the wave Frequency and Amplitude
                    noiseMap[x, y] += wave.amplitude * Mathf.PerlinNoise(samplePosX * wave.frequency + wave.seed, samplePosY * wave.frequency + wave.seed);
                    normalization += wave.amplitude;
                }
                
                // Normalize the value
                noiseMap[x, y] /= normalization;
            }
        }
                
        return noiseMap;
    }
}


// Generate the Wave for the Noise Generation
[System.Serializable]
public class Wave
{
    public float seed;
    public float frequency;
    public float amplitude;
}