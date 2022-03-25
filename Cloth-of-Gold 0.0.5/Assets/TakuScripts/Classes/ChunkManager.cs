using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChunkManager
{
	/// <summary>
	/// this is where all the chunks are stored. they are stored away from the world controller
	/// as that does not really need to know whats going on on the inside. This is just to reduce
	/// complexity and just give the world controller single purpose.
	/// 
	/// The single purpose of this class is to just manage chunks. Chunks go into
	/// further details about themselves, but the chunk manager just needs easy access to them
	/// </summary>
	private int chunkSize;
	public Chunk activeChunk;
	public List<Chunk> chunkList => new List<Chunk>(_chunks);
	private List<Chunk> _chunks;
	private Vector2Int worldSizeInChunks;

	public void FloodChunkWithTile(TileBase tile, Chunk chunk) => chunk.tiles.Populate(tile);
	public void FloodChunkWithTile(RootTile_SO rootTile, Chunk chunk) => chunk.tiles.Populate(rootTile.tiles.ToArray());
	public void FloodAllChunksWithTile(TileBase tile) => _chunks.ForEach((a) => FloodChunkWithTile(tile, a));
	public void FloodAllChunksWithTile(RootTile_SO rootTile) => _chunks.ForEach((a) => FloodChunkWithTile(rootTile, a));

	public ChunkManager(Vector2Int worldSizeInChunks, int chunkSize) {
		this.worldSizeInChunks = worldSizeInChunks;
		this.chunkSize = chunkSize;
		_chunks = new List<Chunk>();
		CreateEmptyChunks();
	}

	/// <summary>
	/// just a nice way to turn any coord into a chunk. there is no safety on this method however
	/// eg, if it cannot find a chunk, it will just return null. maybe a good idea to have the program
	/// do a critical fail here. or clamp the world pos to the world size so you are assured that its
	/// always inside the scope of the world
	/// </summary>
	public Chunk GetChunk(Vector3Int worldPos) {
		foreach(Chunk c in _chunks) {
			if (c.inChunkBounds(worldPos)) {
				return c;
			}
		}
		return null;
	}


	/// <summary>
	/// This only sets the data inside the chunk, it does not render the data
	/// </summary>
	public void SetTile(Vector3Int worldPos, RootTile_SO tile) {
		TileBase rndTile = tile.tiles[UnityEngine.Random.Range(0, tile.tiles.Count)];
		Chunk c = GetChunk(worldPos);
		int i = 0;
		try {
			i = Array.IndexOf(c.tilePositions, worldPos);
			c.tiles[i] = rndTile;
		}
		catch {
			Debug.Log($"{i} ");
		}
	}
	/// <summary>
	/// Blank initiation of chunks
	/// </summary>
	private void CreateEmptyChunks() {
		for (int x = 0; x < worldSizeInChunks.x; x++) {
            for (int y = 0; y < worldSizeInChunks.y; y++)
            {

                int xPos = Mathf.FloorToInt(x - (worldSizeInChunks.x * chunkSize / 2));
                int yPos = Mathf.FloorToInt(y - (worldSizeInChunks.y * chunkSize / 2));

                Vector3Int chunkStartLocalPos = new Vector3Int(x, y, 0);
				Vector3Int chunkStartWorldPos = chunkStartLocalPos * chunkSize;
				Chunk chunk = new Chunk(chunkStartWorldPos, chunkSize);
				_chunks.Add(chunk);
			}
		}
	}
}
