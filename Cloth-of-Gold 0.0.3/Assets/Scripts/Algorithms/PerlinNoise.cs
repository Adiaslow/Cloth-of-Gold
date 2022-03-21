using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{

    public bool isInit { get; private set; } = false;

    
    public float GetPerlinNoiseAt(int x, int y, float scale, float heightMultiplier, int octaves, float persistance, float lacunarity, float xOffset, float yOffset)
    {
        float PerlinValue = 0f;
        float amplitude = 1f;
        float frequency = 1f;

        for (int i = 0; i < octaves; i++)
        {
            PerlinValue += Mathf.PerlinNoise((x / scale + xOffset) * frequency, (y / scale + yOffset) * frequency) * amplitude;
            amplitude *= persistance;
            frequency *= lacunarity;
        }

        // Return the noise value
        return PerlinValue * heightMultiplier;
    }
    
}
