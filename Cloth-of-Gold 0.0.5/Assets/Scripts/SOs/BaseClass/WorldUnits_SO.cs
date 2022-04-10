using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CoG/New WorldUnits", fileName = "New World Units")]
public class WorldUnits_SO : ScriptableObject
{
	public List<RootUnit_SO> rootUnits = new List<RootUnit_SO>();
}

