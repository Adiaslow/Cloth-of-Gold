using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileType tileType;

    public enum TileType { Test, Grass, FurtileGrass, DryGrass, Dirt }

    private SpriteRenderer _tileSprite;

    switch (tileType)
    {
        case Test:
        _tileSprite = 
    }
}

