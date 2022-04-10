using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CoG/New World Structures", fileName = "New World Structures")]
public class WorldStructures_SO : ScriptableObject
{
	public List<RootStructure_SO> rootUnits = new List<RootStructure_SO>();
}

