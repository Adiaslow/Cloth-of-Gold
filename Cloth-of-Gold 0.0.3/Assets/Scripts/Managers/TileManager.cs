using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    private List<Tile> _tiles = new List<Tile>();

    [SerializeField] private Sector _sectorPrefab;
    private List<Sector> _sectors = new List<Sector>();

    public int sectorCount = 2;
    public int SECTOR_SIZE;

    public int WIDTH;
    public int HEIGHT;

    public int TILE_COUNT = 0;
    public int SECTOR_COUNT = 0;

    [SerializeField] private float scale = 1;
    [SerializeField] private float heightMultiplier = 100;
    [SerializeField] [Range(0, 10)] private int octaves = 4;
    [SerializeField] [Range(-3.5f, 0)] private float persistance = 0.5f;
    [SerializeField] [Range(0, 1)] private float lacunarity = 0.5f;
    [SerializeField] private float xOffset = 0;
    [SerializeField] private float yOffset = 0;

    [SerializeField] private Camera _camera;

    private void Start()
    {
        SECTOR_SIZE = _sectorPrefab.SECTOR_SIZE;

        GetWidthAndHeight();
        CreateSectors();
    }

    private void Update()
    {
        // UpdateTileType();
    }

    private void GetWidthAndHeight()
    {
        if (sectorCount == 0)
        {
            WIDTH = HEIGHT = 0;
        }

        else if (sectorCount % 2 != 0)
        {
            WIDTH = SECTOR_SIZE * sectorCount;
        }

        else
        {
            WIDTH = SECTOR_SIZE * sectorCount;
            HEIGHT = SECTOR_SIZE * sectorCount / 2;
        }

    }

    private void CreateSectors()
    {
        int _tileIndex = 0;
        int _sectorIndex = 0;
        int _sectorXValue = 0;
        int _sectorYValue = 0;
        int _tileXValue = 0;
        int _tileYValue = 0;

        float xPos;
        float yPos;

        for (int y = 0; y < HEIGHT; y += 8)
        {
            _sectorXValue = 0;

            for (int x = 0; x < WIDTH; x += 8)
            {
                _sectors.Add(Instantiate(_sectorPrefab));

                _sectors[_sectorIndex].name = _sectorXValue + " " + _sectorYValue + " Sector";

                _sectors[_sectorIndex].transform.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);

                _sectors[_sectorIndex].transform.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(SECTOR_SIZE, SECTOR_SIZE);


                // _sectors[_sectorIndex].transform.gameObject.SetActive(false);


                xPos = x - WIDTH / 2 + SECTOR_SIZE / 2;
                yPos = y - HEIGHT / 2 + SECTOR_SIZE / 2;

                _sectors[_sectorIndex].transform.Translate(new Vector2(xPos, yPos));

                SECTOR_COUNT++;

                for (int m = 0; m < SECTOR_SIZE; m++)
                {
                    for (int n = 0; n < SECTOR_SIZE; n++)
                    {
                        _tiles.Add(Instantiate(_tilePrefab));

                        _tileXValue = x + n;
                        _tileYValue = x + m;

                        _tiles[_tileIndex].name = _tileXValue + " " + _tileYValue + " Tile";

                        _tiles[_tileIndex].transform.SetParent(_sectors[_sectorIndex].transform);

                        if (_tileIndex == _sectorIndex)
                        {
                            // _tiles[_tileIndex].transform.gameObject.SetActive(true);
                        }

                        _tiles[_tileIndex].tileType.RetrieveTileType(_tiles[_tileIndex], x + n, y + m, scale, heightMultiplier, octaves, persistance, lacunarity, xOffset, yOffset);

                        xPos = x + n - WIDTH / 2 + 0.5f;
                        yPos = y + m - HEIGHT / 2 + 0.5f;

                        _tiles[_tileIndex].transform.Translate(new Vector2(xPos, yPos));

                        _tileIndex++;

                        TILE_COUNT++;
                    }
                }

                _sectorXValue++;
                _sectorIndex++;
            }

            _sectorYValue++;
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
                for (int m = 0; m < SECTOR_SIZE; m++)
                {
                    for (int n = 0; n < SECTOR_SIZE; n++)
                    {
                        // IsSectorActive(_tileIndex, _parentIndex);
                        // UpdateTileType(_tileIndex, x, y);
                    }
                }
            }
        }
    }

    private void IsSectorActive(int _tileIndex, int _parentIndex)
    {
        if (_tiles[_tileIndex].tileRenderer.GetComponent<Renderer>().isVisible)
        {
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

 
}
