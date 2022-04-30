using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Root Tile", menuName = "CoG/New Root Tile")]
public class RootTile_SO : ScriptableObject
{

	public bool isFatal;
	public bool isBuildable;
    public bool isFarmable;

    public enum FarmType { None, Dry, Average, Fertile };

    [Range(0, 100)] public int flammability;



    public List<TileBase> tiles;

}
