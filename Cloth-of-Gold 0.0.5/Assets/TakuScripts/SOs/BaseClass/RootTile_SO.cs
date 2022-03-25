using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "New Root Tile", menuName = "CoG/New Root Tile")]
public class RootTile_SO : ScriptableObject
{
	public List<TileBase> tiles;

	public TileBase getRndTile() => tiles[UnityEngine.Random.Range(0, tiles.Count)];
}
