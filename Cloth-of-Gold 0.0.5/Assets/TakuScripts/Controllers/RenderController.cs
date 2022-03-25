using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RenderController : MonoBehaviour
{
    public Transform renderPoint;
	public Vector2Int renderSize;
	private ChunkManager cm;
	private HashSet<Chunk> activeChunks;
	private Queue<Chunk> Q_unrenderChunks;
	private Queue<Chunk> Q_renderChunks;
	private Vector3 renPos => renderPoint.position;
	private Vector3Int floorPos;
	private Vector2Int center;
	public Vector2Int start;
	public Vector2Int end;
	private Vector2Int oldCenter;
	private int chunkSize => WorldController._instance.getChunkSizeInTiles;




	private void Start() {
		cm = WorldController._instance.getChunkManager;
		activeChunks = new HashSet<Chunk>();
		Q_unrenderChunks = new Queue<Chunk>();
		Q_renderChunks = new Queue<Chunk>();
		oldCenter = new Vector2Int(-100, -100);
		updateRenderPointPosition();
		Chunk c = cm.GetChunk(floorPos);
		Q_renderChunks.Enqueue(c);
	}

	private void EnqueueValidChunks() {
		SetLocalRenderPoint();
		oldCenter = center;
		start = center - renderSize;
		end = center + renderSize;
		for (int x = start.x; x <= end.x; x++) {
			for (int y = start.y; y <= end.y; y++) {
				Vector2Int curPos = new Vector2Int(x, y);
				if (activeChunks.Any(a => a.start / chunkSize == (Vector3Int)curPos)) continue;
				Chunk c = cm.GetChunk((Vector3Int)curPos * chunkSize);
				if (c != null) {
					activeChunks.Add(c);
					Q_renderChunks.Enqueue(c);
				}
			}
		}
	}
	private bool CheckValidRender(Vector2Int cl) => (cl.x >= start.x && cl.x <= end.x) && (cl.y >= start.y && cl.y <= end.y);

	private void EnqueueInvalidChunks() {
		List<Chunk> remover = activeChunks.Where(a => CheckValidRender((Vector2Int)a.start / chunkSize) == false).ToList();
		foreach(Chunk c in remover) {
			activeChunks.Remove(c);
			Q_unrenderChunks.Enqueue(c);
		}
	}

	private void SetLocalRenderPoint() {
		center = Vector2Int.FloorToInt(renderPoint.position);
		center = center / 16;
	}

	private void updateRenderPointPosition() {
		SetLocalRenderPoint();
		if (center != oldCenter) {
			oldCenter = center;
			ChunkUpdate();
			RenderEnqueuedChunks();
		}
	}
	private void Update() {
		updateRenderPointPosition();
	}

	private void ChunkUpdate() {
		start = center - renderSize;
		end = center + renderSize;
		EnqueueValidChunks();
		EnqueueInvalidChunks();
	}

	private void RenderEnqueuedChunks() {

		while (Q_unrenderChunks.Count > 0) {
			var c = Q_unrenderChunks.Dequeue();
			WorldController.CB_UnrenderChunk(c);
		}
		while (Q_renderChunks.Count > 0) {
			var c = Q_renderChunks.Dequeue();
			WorldController.CB_RenderChunk(c);
		}
	}
}
