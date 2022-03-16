using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static int WIDTH = 10;
    public static int HEIGHT = 10;

    [SerializeField] public Tile _tilePrefab;

    private Tile _spawnedTile;

    private void Start()
    {
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                string _tileName = x + " " + y;

                _spawnedTile = Instantiate(_tilePrefab);

                Tile _tileData = _tilePrefab.InitTile(Tile.TileType.Test, _tileName, new Vector2(x, y));

                _spawnedTile.transform.Translate(_tileData.tilePos);
            }
        }
    }
    
}
