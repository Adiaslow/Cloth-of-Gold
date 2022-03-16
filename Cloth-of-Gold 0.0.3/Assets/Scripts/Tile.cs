using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _tileRenderer;

    private Tile tileData;

    // Tile variables
    public TileType tileType { get; private set; }
    public string tileName { get; private set; }
    public Vector2 tilePos { get; private set; }

    public enum TileType { Test, Grass, FertileGrass, DryGrass, Dirt }

    // Editor sprite assignment
    [SerializeField] private Sprite[] _spriteArray;

    public bool isInit { get; private set; } = false;


    // Confirms that all variables are assigned
    public Tile InitTile(TileType _tileType, string _tileName, Vector2 _tilePos)
    {

        bool _success = true;
        _success = tileData.SetTileType(_tileType);
        _success = tileData.SetTileName(_tileName);
        _success = tileData.SetTilePos(_tilePos);

        tileData.isInit = _success;

        if (isInit == true)
        {
            Debug.Log("TileSpawned!");
            return tileData;
        }
        else
        {
            Debug.Log("Tile is not initialized properly.");
            return tileData;
        }
    }

    // Public method for setting tile type
    public bool SetTileType(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Dirt:
                tileData.tileType = TileType.Dirt;
                tileData._tileRenderer.sprite = _spriteArray[0];
                break;

            case TileType.DryGrass:
                tileData.tileType = TileType.DryGrass;
                tileData._tileRenderer.sprite = _spriteArray[1];
                break;

            case TileType.Grass:
                tileData.tileType = TileType.Grass;
                tileData._tileRenderer.sprite = _spriteArray[2];
                break;

            case TileType.FertileGrass:
                tileData.tileType = TileType.FertileGrass;
                tileData._tileRenderer.sprite = _spriteArray[3];
                break;

            default:
                tileData.tileType = TileType.Test;
                tileData._tileRenderer.sprite = _spriteArray[4];
                break;
        }

        return true;
    }

    public bool SetTileName(string tileID)
    {
        tileData.tileName = tilePos + " " + tileType;
        return true;
    }

    public bool SetTilePos(Vector2 _tilePos)
    {
        tileData.tilePos = _tilePos;
        return true;
    }

    public GameObject GetTile()
    {
        GameObject _tilePrefab = new GameObject();
        return _tilePrefab;
    }
}

    /*
    // Confirms that all variables are assigned
    public GameObject SetTileInfo(TileType _tileType, int _tilePosX, int _tilePosY)
    {
        
        bool _success = true;
        _success = tileData.SetTileType(_tileType);
        _success = tileData.SetTilePos(_tilePosX, _tilePosY);

        tileData.isInit = _success;

        if (isInit == true)
        {
            return null;
        }
        else
        {
            Debug.Log("Tile is not initialized properly.");
            return null;
        }
    }

    // Public method for setting tile type
    public bool SetTileType(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Dirt:
                tileData.tileType = TileType.Dirt;
                tileData._tileRenderer.sprite = _dirt;
                break;

            case TileType.DryGrass:
                tileData.tileType = TileType.DryGrass;
                tileData._tileRenderer.sprite = _dryGrass;
                break;

            case TileType.Grass:
                tileData.tileType = TileType.Grass;
                tileData._tileRenderer.sprite = _grass;
                break;

            case TileType.FertileGrass:
                tileData.tileType = TileType.FertileGrass;
                tileData._tileRenderer.sprite = _fertileGrass;
                break;

            default:
                tileData.tileType = TileType.Test;
                tileData._tileRenderer.sprite = _test;
                break;
        }

        return true;
    }

    public bool SetTileID(string tileID)
    {
        tileData.tileName = tilePosX + " " + tilePosY + " " + tileType;
        return true;
    }

    public bool SetTilePos(int x, int y)
    {
        tileData.tilePosX = x;
        tileData.tilePosY = y;
        return true;
    }

    public GameObject GetTile()
    {
        GameObject _tilePrefab = new GameObject();
        return _tilePrefab;
    }
    */