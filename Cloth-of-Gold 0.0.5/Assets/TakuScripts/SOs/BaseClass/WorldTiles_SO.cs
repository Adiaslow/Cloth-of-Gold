using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CoG/New WorldTiles", fileName = "New World Tiles")]
public class WorldTiles_SO : ScriptableObject
{
	public List<RootTile_SO> rootTiles = new List<RootTile_SO>();
}
