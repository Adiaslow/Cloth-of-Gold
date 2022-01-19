// GOOD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseManager : MonoBehaviour
{
    public int x { get; private set; }
    public int y { get; private set; }
    public float scale { get; private set; }
    public float heightMultiplier { get; private set; }
    public int octaves { get; private set; }
    public float persistance { get; private set; }
    public float lacunarity { get; private set; }
    public float xOffset { get; private set; }
    public float yOffset { get; private set; }
    public bool isInit { get; private set; } = false;

    public static float GetPerlinNoiseAt(int x, int y, float scale, float heightMultiplier, int octaves, float persistance, float lacunarity, float xOffset, float yOffset)
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
    public bool Init_PN(int _x, int _y, float _scale, float _heightMultiplier, int _octaves, float _persistance, float _lacunarity, float _xOffset, float _yOffset)
    {
        bool _success = true;
        _success = this.SetX(_x);
        _success = this.SetY(_y);
        _success = this.SetScale(_scale);
        _success = this.SetHeightMultiplier(_heightMultiplier);
        _success = this.SetOctaves(_octaves);
        _success = this.SetPersistance(_persistance);
        _success = this.SetLacunarity(_lacunarity);
        _success = this.SetXOffset(_xOffset);
        _success = this.SetYOffset(_yOffset);

        this.isInit = _success;

        return true;
    }

    public bool SetX(int xValue)
    {
        this.x = xValue;
        return true;
    }

    public bool SetY(int yValue)
    {
        this.y = yValue;
        return true;
    }

    public bool SetScale(float scaleValue)
    {
        this.scale = scaleValue;
        return true;
    }

    public bool SetHeightMultiplier(float heightMultiplierValue)
    {
        this.heightMultiplier = heightMultiplierValue;
        return true;
    }

    public bool SetOctaves(int octavesValue)
    {
        this.octaves = octavesValue;
        return true;
    }

    public bool SetPersistance(float persistanceValue)
    {
        this.persistance = persistanceValue;
        return true;
    }

    public bool SetLacunarity(float lacunarityValue)
    {
        this.lacunarity = lacunarityValue;
        return true;
    }

    public bool SetXOffset(float xOffsetValue)
    {
        this.xOffset = xOffsetValue;
        return true;
    }

    public bool SetYOffset(float yOffsetValue)
    {
        this.yOffset = yOffsetValue;
        return true;
    }
}
