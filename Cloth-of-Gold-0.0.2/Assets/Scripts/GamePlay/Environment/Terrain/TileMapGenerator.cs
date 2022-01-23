// PLEASE!! FIX ME!!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerator : MonoBehaviour
{
    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private TileManager _tileManager;
    [SerializeField] private TileData _tileData;

    public void GenerateTerrain()
    {
        var terrainGrid = _gridGenerator.GenerateTileGrid();

        int _width = terrainGrid.GetLength(0);
        int _height = terrainGrid.GetLength(1);

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                string tileName = $"Tile {x} {y}";
                int tilePosX = x;
                int tilePosY = y;
                Quaternion tileRot = Quaternion.identity;

                _tileData.InitTile(default, tileName, tilePosX, tilePosY , tileRot);

                
                // var spawnedTile = Instantiate(_tileData.GetTile(), new Vector2(x,y), Quaternion.identity);

                terrainGrid[x, y] = _tileData.GetTile();

                //// terrainGrid[x, y].name = $"Tile {x} {y}";

                _tileManager.SetTiles(x, y, terrainGrid[x, y]);

                // SetPlayerArea(x, _width, spawnedTile, playerAreaSizePercent);

                // _tileManager.GetTiles()[new Vector2(x, y)] = spawnedTile;
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
