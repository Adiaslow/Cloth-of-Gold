using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Root Cursor", menuName = "CoG/New Root Cursor")]
public class RootCursor_SO : ScriptableObject
{
	public List<TileBase> cursors;
}
