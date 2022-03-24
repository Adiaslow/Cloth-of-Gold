using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChunkManager
{
    private int chunkSize;
    public Chunk activeChunk;
    public List<Chunk> chunkList => new List<Chunk>(_chunks);
    private List<Chunk> _chunks;
    private Vector2Int worldSizeInChunks;

    public void FloodChunkWithTile(TileBase tile, Chunk chunk) => chunk.tiles.Populate(tile);
    public void FloodAllChunksWithTile(TileBase tile) => _chunks.ForEach((a) => FloodChunkWithTile(tile, a));

    public ChunkManager(Vector2Int worldSizeInChunks, int chunkSize)
    {
        this.worldSizeInChunks = worldSizeInChunks;
        this.chunkSize = chunkSize;
        _chunks = new List<Chunk>();
        CreateEmptyChunks();
    }


    private void CreateEmptyChunks()
    {
        for (int x = 0; x < worldSizeInChunks.x; x++)
        {
            for (int y = 0; y < worldSizeInChunks.y; y++)
            {
                Vector3Int chunkStartLocalPos = new Vector3Int(x, y, 0);
                Vector3Int chunkStartWorldPos = chunkStartLocalPos * chunkSize;
                Chunk chunk = new Chunk(chunkStartWorldPos, chunkSize);
                _chunks.Add(chunk);
            }
        }
    }
}
