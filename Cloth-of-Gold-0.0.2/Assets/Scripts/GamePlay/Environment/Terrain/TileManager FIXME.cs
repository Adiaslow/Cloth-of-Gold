using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Sprite _test, _dirt, _grass, _dryGrass, _fertileGrass;

    /*
    [SerializeField, Range(1.0f, 100.0f)] private float noiseScale = 1.0f;
    [SerializeField, Range(0.0f, 200.0f)] private float heightMultiplier = 100.0f;
    [SerializeField, Range(0, 10)] private int octaves = 4;
    [SerializeField, Range(-1.0f, 1.0f)] private float persistance = 0.0f;
    [SerializeField, Range(0.0f, 1.0f)] private float lacunarity = 0.0f;
    [SerializeField] private float xOffset = 0.0f;
    [SerializeField] private float yOffset = 0.0f;
    [SerializeField, Range(5, 50)] int playerAreaSizePercent = 50;

    [SerializeField] private TileData _tilePrefab;
    private Dictionary<Vector2, TileData> tiles;

    public void SetTiles(int x, int y, TileData spawnedTile)
    {

        var TileType = 0;

        TileType = (int)Mathf.Round(NoiseMap.GetNoiseAt(x, y, noiseScale, heightMultiplier, octaves, persistance, lacunarity, xOffset, yOffset));

        if (TileType >= 0 && TileType < 25)
        {
            TileType = 0;
            spawnedTile.SetTileType(TileType);
        }

        if (TileType >= 25 && TileType < 50)
        {
            TileType = 1;
            spawnedTile.SetTileType(TileType);
        }

        if (TileType >= 50 && TileType < 75)
        {
            TileType = 2;
            spawnedTile.SetTileType(TileType);
        }

        if (TileType >= 75 && TileType < 101)
        {
            TileType = 3;
            spawnedTile.SetTileType(TileType);
        }

        tiles[new Vector2(x, y)] = spawnedTile;
    }

    public Dictionary<Vector2, TileData> GetTiles()
    {
        return tiles;
    }
    */
}
