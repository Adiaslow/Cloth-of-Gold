using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnitManager
{

    private TileBase[] units;
    public Vector3Int[] unitPositions;

    public void IncreaseUnitCount(Vector3Int unitPos, TileBase unit)
    {
        int unitCount = units.Length;

        units[unitCount] = (unit);
        unitPositions[unitCount] = unitPos;
        unitCount++;
    }

    public void DecreaseUnitCount(Vector3Int unitPos, TileBase unit)
    {
        int unitCount = units.Length;

        units[unitCount] = null;
        unitCount--;
    }

}
