using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this as an idea to make different algos
/// </summary>
[CreateAssetMenu(fileName ="New Perlin Gen", menuName = "CoG/Generation Types/Perlin", order = 0)]
public class WorldGen_Perlin : WorldGen
{
	public PerlinNoise_SO basePerlin;
	public Distribution_SO baseDistro;
	private Vector2Int WorldSizeInChunks;
	private int chunkSizeInTiles;

	public override void doWorldTransform() {
		buildPerlin();
		WorldSizeInChunks = WorldController._instance.getWorldSizeInChunks;
		chunkSizeInTiles = WorldController._instance.getChunkSizeInTiles;
	}

	private void buildPerlin() {
		Vector2Int worldTileSize = WorldSizeInChunks * chunkSizeInTiles;
		PerlinGenerator pergen = new PerlinGenerator(basePerlin);
		for (int x = 0; x < worldTileSize.x; x++) {
			for (int y = 0; y < worldTileSize.y; y++) {
				perlinAt(pergen, x, y);
			}
		}
	}

	private void perlinAt(PerlinGenerator pergen, int x, int y) {
		Vector3Int curPos = new Vector3Int(x, y, 0);
		float perl = pergen.GetPerlinNoiseAt(curPos.x, curPos.y);
		RootTile_SO rootTile = baseDistro.tileDistributionList[getIndexOfPerl(perl)];
		WorldController.CB_SetTile(curPos, rootTile);
		
	}

	private int getIndexOfPerl(float perl) {
		for (int i = 0; i < baseDistro.amounts.Length; i++) {
			float min = baseDistro.amounts[i];
			float max = i == baseDistro.amounts.Length - 1 ? 100 : baseDistro.amounts[i + 1];
			if(perl >= min && perl<= max) {
				return i;
			}
		}
		return 0;
	}
}
