using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this is just a handy container so you can setup different world generation orders
/// </summary>
[CreateAssetMenu(fileName = "New World Transforms", menuName = "CoG/New World Transforms")]
public class WorldTransformer_SO : ScriptableObject
{
    public List<WorldGen> worldGens;
}
