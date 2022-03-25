using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Distribution", menuName = "CoG/New Distribution")]
public class Distribution_SO : ScriptableObject
{
	public List<RootTile_SO> tileDistributionList;
	public float[] amounts;
}
