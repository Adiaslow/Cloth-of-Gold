using UnityEngine;
using System.Collections;

public class SetTileType : MonoBehaviour
{

    [SerializeField] public PerlinNoise _pNoise;

    public enum TileType { Dirt = 0, DryGrass = 1, Grass = 2, FertileGrass = 3, Water = 4, Test = 5}

    [SerializeField] private Sprite[] _spriteArray;

    [SerializeField] public float[] _tileTypeArray;

    public Tile RetrieveTileType(Tile _spawnedTile, int x, int y, float scale, float heightMultiplier, int octaves, float persistance, float lacunarity, float xOffset, float yOffset)
    {
        float _noiseValue = _pNoise.GetPerlinNoiseAt(x, y, scale, heightMultiplier, octaves, persistance, lacunarity, xOffset, yOffset);

            // Dirt
            if (_noiseValue >= _tileTypeArray[0] && _noiseValue < _tileTypeArray[1])
                
                _spawnedTile.tileRenderer.sprite = _spriteArray[0];

            // Fertile Grass
            else if (_noiseValue >= _tileTypeArray[1] && _noiseValue < _tileTypeArray[2])

                _spawnedTile.tileRenderer.sprite = _spriteArray[1];

            // Grass
            else if (_noiseValue >= _tileTypeArray[2] && _noiseValue < _tileTypeArray[3])

                _spawnedTile.tileRenderer.sprite = _spriteArray[2];

            // Dry Grass
            else if (_noiseValue >= _tileTypeArray[3] && _noiseValue <= _tileTypeArray[4])

                _spawnedTile.tileRenderer.sprite = _spriteArray[3];

            // Water
            else
                _spawnedTile.tileRenderer.sprite = _spriteArray[4];

        return _spawnedTile;
    }
}
