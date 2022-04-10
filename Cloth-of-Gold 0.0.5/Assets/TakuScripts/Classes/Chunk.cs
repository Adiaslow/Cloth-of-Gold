using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Chunk
{
	public Vector3Int start;
	public Vector3Int end => start.With(x: start.x + size, y: start.y + size);
	public TileBase[] tiles;
	public Vector3Int[] tilePositions;
	private int size;
	private int chunkTileTotalCount;


	public bool inChunkBounds(Vector3Int worldPos) {
		if (worldPos.x >= start.x && worldPos.x < end.x) {
			if (worldPos.y >= start.y && worldPos.y < end.y)
				return true;
		}
		return false;
	}

	private void initArray<T>(ref T[] array) =>	array = new T[chunkTileTotalCount];

	public Chunk(Vector3Int chunkStartPos, int chunkSize) {
		this.start = chunkStartPos;
		this.size = chunkSize;
		chunkTileTotalCount = chunkSize * chunkSize;

		initArray(ref tiles);
		initArray(ref tilePositions);

		PopulateTilePositions();
	}


	private void PopulateTilePositions() {
		int i = 0;
		for (int x = start.x; x < end.x; x++) {
			for (int y = start.y; y < end.y; y++) {
				tilePositions[i] = new Vector3Int(x, y, 0);
				i++;
			}
		}
	}
}
