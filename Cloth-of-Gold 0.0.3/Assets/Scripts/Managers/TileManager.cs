using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Camera _camera;

    private List<Tile> _tiles = new List<Tile>();

    public int WIDTH = 10;
    public int HEIGHT = 10;

    [SerializeField] private float scale = 1;
    [SerializeField] private float heightMultiplier = 100;
    [SerializeField] [Range(0, 10)] private int octaves = 4;
    [SerializeField] [Range(-3.5f, 0)] private float persistance = 0.5f;
    [SerializeField] [Range(0, 1)] private float lacunarity = 0.5f;
    [SerializeField] private float xOffset = 0;
    [SerializeField] private float yOffset = 0;

    private void Start()
    {
        CreateTiles();
    }

    private void Update()
    {
        UpdateTileType();
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

    private void UpdateTileType()
    {
        int _tileIndex = 0;

        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                _tiles[_tileIndex].tileType.RetrieveTileType(_tiles[_tileIndex], x, y, scale, heightMultiplier, octaves, persistance, lacunarity, xOffset, yOffset);

                _tileIndex++;
            }
        }
    }
}
