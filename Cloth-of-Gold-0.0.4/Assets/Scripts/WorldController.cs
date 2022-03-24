using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldController : MonoBehaviour
{
    public static event Action<Vector3Int> CB_SetTile;

    public Tilemap worldTilemap;
    private ChunkManager chunkManager;
    [SerializeField] private TileBase defaultTile;
    [SerializeField] private int chunkSizeInTiles = 16;
    [SerializeField] private Vector2Int WorldSizeInChunks = Vector2Int.one;
    private PerlinNoise_SO PerlinNoise;

    private void Awake()
    {
        CB_SetTile += SetTile;
        chunkManager = new ChunkManager(WorldSizeInChunks, chunkSizeInTiles);

        chunkManager.FloodAllChunksWithTile(defaultTile);
        RenderAllChunks();
    }

    private void RenderAllChunks()
    {
        var chunks = chunkManager.chunkList;
        foreach (Chunk chunk in chunks)
        {
            worldTilemap.SetTiles(chunk.tilePositions, chunk.tiles);
        }
    }

    private void SetTile(Vector3Int tilePos)
    {
        float noiseValue = PerlinNoise.GetPerlinNoiseAt(tilePos);
    }


    //callback here to set tiles from player

}