using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinGenerator 
{
    private PerlinNoise_SO data;

	public PerlinGenerator(PerlinNoise_SO data) => this.data = data;

    public float GetPerlinNoiseAt(int x, int y) {
        float PerlinValue = 0f;
        float amplitude = 1f;
        float frequency = 1f;

        for (int i = 0; i < data.octaves; i++) {
            amplitude *= data.persistance;
            frequency *= data.lacunarity;
            PerlinValue = Mathf.PerlinNoise((x / data.scale + data.xOffset * frequency) * amplitude, (y / data.scale + data.yOffset * frequency) * amplitude);
        }

        PerlinValue = Mathf.Clamp01(PerlinValue);
        return PerlinValue * data.heightMultiplier;
    }
}
