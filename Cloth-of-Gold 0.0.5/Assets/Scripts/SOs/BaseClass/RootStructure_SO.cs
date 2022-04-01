using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Root Structure", menuName = "CoG/New Root Structure")]
public class RootStructure_SO : ScriptableObject
{
	public List<TileBase> structures;
}
