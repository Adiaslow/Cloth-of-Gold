using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(menuName = "CoG/Perlin Settings", fileName = "New Perlin Settings" )]
public class PerlinNoise_SO : ScriptableObject
{
    public float scale;
    public float heightMultiplier;
    public int octaves;
    public float persistance;
    public float lacunarity;
    public float xOffset;
    public float yOffset;
}
