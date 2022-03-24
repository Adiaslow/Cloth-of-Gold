using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise_SO : MonoBehaviour
{
    public static PerlinNoise_SO PerlinNoise;

    [SerializeField] private float scale = 1;
    [SerializeField] private float heightMultiplier = 100;
    [SerializeField] [Range(0, 10)] private int octaves = 4;
    [SerializeField] [Range(-3.5f, 0)] private float persistance = -0.5f;
    [SerializeField] [Range(0, 1)] private float lacunarity = 0.5f;
    [SerializeField] private float xOffset = 0;
    [SerializeField] private float yOffset = 0;

    void Awake() => PerlinNoise = this;

    public float GetPerlinNoiseAt(Vector3Int pos)
    {
        float PerlinValue = 0f;
        float amplitude = 1f;
        float frequency = 1f;

        for (int i = 0; i < octaves; i++)
        {
            PerlinValue += Mathf.PerlinNoise((pos.x / scale + xOffset) * frequency, (pos.y / scale + yOffset) * frequency) * amplitude;
            amplitude *= persistance;
            frequency *= lacunarity;
        }

        // Return the noise value
        return PerlinValue * heightMultiplier;
    }
}
