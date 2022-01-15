using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int _width, _height;
    public GameObject[,] gridArray;

    [SerializeField] private TileData _tilePrefab;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, TileData> _tiles;

    //var NM = Instantiate(_noiseMap);

    [SerializeField, Range(1.0f, 100.0f)] private float noiseScale = 1.0f;
    [SerializeField, Range(0.0f, 200.0f)] private float heightMultiplier = 100.0f;
    [SerializeField, Range(0, 10)] private int octaves = 4;
    [SerializeField, Range(-1.0f, 1.0f)] private float persistance = 0.0f;
    [SerializeField, Range(0.0f, 1.0f)] private float lacunarity = 0.0f;
    [SerializeField] private float xOffset = 0.0f;
    [SerializeField] private float yOffset = 0.0f;

    [SerializeField, Range(5, 50)] int playerAreaSizePercent = 50;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var pos = new Vector2(x, y);

                var spawnedTile = GetTileAtPosition(pos);

                SetTiles(x, y, spawnedTile);
            }
        }
    }

    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, TileData>();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Cell {x} {y}";

                SetTiles(x, y, spawnedTile);
                SetPlayerArea(x, _width, spawnedTile, playerAreaSizePercent);
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

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

        _tiles[new Vector2(x, y)] = spawnedTile;
    }

    

    public TileData GetTileAtPosition(Vector2 pos)
    {
        if(_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }

    public void SetPlayerArea(int x, int width, TileData spawnedTile, int playerAreaSizePercent)
    {
        var PlayerAreaType = 0;

        int tilesPerPlayer = width / (100 / playerAreaSizePercent);

        if (x >= 0 && x >= tilesPerPlayer) // FIXME
        {
            PlayerAreaType = 2;
            spawnedTile.SetPlayerAreaType(PlayerAreaType);
        }

        if (x <= width && x >= width - tilesPerPlayer)
        {
            PlayerAreaType = 1;
            spawnedTile.SetPlayerAreaType(PlayerAreaType);
        }

        else
        {
            PlayerAreaType = 2;
            spawnedTile.SetPlayerAreaType(PlayerAreaType);
        }
    }

    public int GetPlayerAreaType(TileData spawnedTile)
    {
        return spawnedTile.PlayerAreaType;
    }
}
