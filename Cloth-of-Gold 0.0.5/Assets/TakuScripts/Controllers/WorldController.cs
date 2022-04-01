using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldController : MonoBehaviour
{
	public static WorldController _instance;

	/// <summary>
	/// this call back here is important for you if you want to set your tile data with different
	/// algos. This will not render the tiles, just edit the data for the next tile the chunk loads
	/// handy if you need to do bulk adjustments
	/// </summary>
	public static Action<Vector3Int, RootTile_SO> CB_SetTile;
	public static Action<Chunk> CB_UnrenderChunk;
	public static Action<Chunk> CB_RenderChunk;
	public Vector2Int getWorldSizeInChunks => WorldSizeInChunks;
	public int getChunkSizeInTiles => chunkSizeInTiles;

	public Tilemap worldTilemap;

	private ChunkManager chunkManager;
	public ChunkManager getChunkManager => chunkManager;
	[SerializeField] private WorldTiles_SO worldTiles;
	[SerializeField] private int chunkSizeInTiles = 16;
	[SerializeField] private Vector2Int WorldSizeInChunks = Vector2Int.one;
	[SerializeField] private WorldTransformer_SO worldTransformer;
	[SerializeField] private RenderController rc;

	private void Awake() {
		_instance = this;
		CB_SetTile += SetTile;
		CB_RenderChunk += RenderChunk;
		CB_UnrenderChunk += UnrenderChunk;
		chunkManager = new ChunkManager(WorldSizeInChunks, chunkSizeInTiles);
		DoWorldTransforms();
	}


	/// <summary>
	/// the idea behind this method is to iterate through different algos at the start of the
	///world generation process. the world transformer has a list of world gen types that you
	///can load into it and it will apply all from top to bottom
	/// </summary>

	private void DoWorldTransforms() {
		foreach(WorldGen i in worldTransformer.worldGens) {
			i.doWorldTransform();
		}
	}


	/// <summary>
	/// renders the data that is stored in all chunks (not very performant)
	/// </summary>
	private void RenderAllChunks() {
		var chunks = chunkManager.chunkList;
		foreach (Chunk chunk in chunks) {
			worldTilemap.SetTiles(chunk.tilePositions, chunk.tiles);
		}
	}

	private void RenderChunk(Chunk c) {
		if(c != null)
			worldTilemap.SetTiles(c.tilePositions, c.tiles);
	}

	private void UnrenderChunk(Chunk c) {
		if (c != null) {
			TileBase[] tb = new TileBase[c.tilePositions.Length];
			worldTilemap.SetTiles(c.tilePositions, tb);
		}
	}

	/// <summary>
	/// Finds the chunk to change the data 
	/// NOTE: This does not inherantly update the tiles. just the data.
	/// </summary>
	private void SetTile(Vector3Int tilePos, RootTile_SO rootTile) {
		chunkManager.SetTile(tilePos, rootTile);
	}
}
