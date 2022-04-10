using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnitManager
{
	public WorldController worldController;

    public List<Tile> unitList => new List<Tile>(_units);
    private List<Tile> _units;


	/// <summary>
	/// This only sets the data inside the chunk, it does not render the data
	/// </summary>
	public void SetUnit(Vector3Int worldPos, RootUnit_SO unit)
	{
		TileBase aUnit = _units[0]; // = unit.units[UnityEngine.Random.Range(0, tile.tiles.Count)];
		/*
		Chunk c = GetChunk(worldPos);
		int i = 0;
		try
		{
			i = Array.IndexOf(c.tilePositions, worldPos);
			c.tiles[i] = rndTile;
		}
		catch
		{
			Debug.Log($"{i} ");
		}
		*/
	}
}
