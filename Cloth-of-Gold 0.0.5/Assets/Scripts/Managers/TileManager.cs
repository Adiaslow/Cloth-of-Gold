using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    /*
    [SerializeField] private DEPRICATED_Tile _tilePrefab;
    [SerializeField] private Camera _camera;

    private List<DEPRICATED_Tile> _tiles = new List<DEPRICATED_Tile>();

    public int chunkCount = 2;
    public int CHUNK_SIZE = 8;

    public int WIDTH;
    public int HEIGHT;

    public int TILE_COUNT = 0;

    [SerializeField] private float scale = 1;
    [SerializeField] private float heightMultiplier = 100;
    [SerializeField] [Range(0, 10)] private int octaves = 4;
    [SerializeField] [Range(-3.5f, 0)] private float persistance = 0.5f;
    [SerializeField] [Range(0, 1)] private float lacunarity = 0.5f;
    [SerializeField] private float xOffset = 0;
    [SerializeField] private float yOffset = 0;

    private void Start()
    {
        GetWidthAndHeight();
        CreateChunks();
        // CreateTiles();
    }

    private void Update()
    {
        // UpdateTileType();
    }

    private void CreateTiles()
    {
        int _tileIndex = 0;

        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {

                _tiles.Add(Instantiate(_tilePrefab));


                _tiles[_tileIndex].GetComponent<Renderer>().enabled = true;

                _tiles[_tileIndex].name = x + " " + y;


                _tiles[_tileIndex].tileType.RetrieveTileType(_tiles[_tileIndex], x, y, scale, heightMultiplier, octaves, persistance, lacunarity, xOffset, yOffset);

                float xPos = x - WIDTH / 2 + 0.5f;
                float yPos = y - HEIGHT / 2 + 0.5f;

                _tiles[_tileIndex].transform.Translate(new Vector2(xPos, yPos));

                _tileIndex++;
            }
        }
    }

    private void GetWidthAndHeight()
    {
        if (chunkCount == 0)
        {
            WIDTH = HEIGHT = 0;
        }

        else if (chunkCount % 2 != 0)
        {
            WIDTH = CHUNK_SIZE * chunkCount;
        }

        else if (chunkCount % 2 == 0)
        {
            WIDTH = CHUNK_SIZE * chunkCount;
            HEIGHT = CHUNK_SIZE * chunkCount / 2;
        }

    }

    private void CreateChunks()
    {
        int _tileIndex = 0;
        int _lastParentIndex = 0;
        int nominalXValue;
        int nominalYValue;

        
        for (int y = 0; y < HEIGHT; y += 8)
        {
            for (int x = 0; x < WIDTH; x += 8)
            {
                for (int m = 0; m < CHUNK_SIZE; m++)
                {
                    for (int n = 0; n < CHUNK_SIZE; n++)
                    {
                        _tiles.Add(Instantiate(_tilePrefab));

                        if (x == 0 && y == 0)
                        {
                            nominalXValue = m;
                            nominalYValue = n;
                        }

                        else
                        {
                            nominalXValue = x + n;
                            nominalYValue = y + m;
                        }

                        if (m == 0 && n == 0)
                        {
                            _tiles[_tileIndex].name = nominalXValue + " " + nominalYValue + " Parent";
                            _lastParentIndex = _tileIndex;
                        }
                        else
                        {
                            _tiles[_tileIndex].name = nominalXValue + " " + nominalYValue + " Child";

                            _tiles[_tileIndex].transform.SetParent(_tiles[_lastParentIndex].transform);
                        }

                        if (_tileIndex == _lastParentIndex)
                        {
                            // _tiles[_tileIndex].transform.gameObject.SetActive(true);
                        }

                        _tiles[_tileIndex].tileType.RetrieveTileType(_tiles[_tileIndex], x + n, y + m, scale, heightMultiplier, octaves, persistance, lacunarity, xOffset, yOffset);

                        float xPos = x + n - WIDTH / 2 + 0.5f;
                        float yPos = y + m - HEIGHT / 2 + 0.5f;

                        _tiles[_tileIndex].transform.Translate(new Vector2(xPos, yPos));

                        _tileIndex++;

                        TILE_COUNT++;
                    }
                }
            }
        }
    }

    private void UpdateLoop()
    {
        int _tileIndex = 0;
        int _parentIndex = 0;
        for (int y = 0; y < HEIGHT; y += 8)
        {
            for (int x = 0; x < WIDTH; x += 8)
            {
                for (int m = 0; m < CHUNK_SIZE; m++)
                {
                    for (int n = 0; n < CHUNK_SIZE; n++)
                    {
                        IsChunkActive(_tileIndex, _parentIndex);
                        // UpdateTileType(_tileIndex, x, y);
                    }
                }
            }
        }
    }

    private void IsChunkActive(int _tileIndex, int _parentIndex)
    {
        if (_tiles[_tileIndex].tileRenderer.GetComponent<Renderer>().isVisible)
        {
            // viewPortRect = Camera.GetComponent<View>
            _tiles[_parentIndex].transform.gameObject.SetActive(true);
        }

        else
        {
            _tiles[_parentIndex].transform.gameObject.SetActive(false);
        }
    }

    private void UpdateTileType(int _tileIndex, int x, int y)
    {
        _tiles[_tileIndex].tileType.RetrieveTileType(_tiles[_tileIndex], x, y, scale, heightMultiplier, octaves, persistance, lacunarity, xOffset, yOffset);

        _tileIndex++;
    }
    */
 
}
