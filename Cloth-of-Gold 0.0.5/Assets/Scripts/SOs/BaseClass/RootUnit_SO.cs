using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Root Unit", menuName = "CoG/New Root Unit")]
public class RootUnit_SO : ScriptableObject
{
	public List<TileBase> units;
}
