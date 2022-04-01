using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Unit
{
    public Vector3Int start;
    public Vector3Int end => start.With(x: start.x, y: start.y);
    public TileBase[] units;
    public Vector3Int[] unitPositions;
    private int unitTotalCount;
    public bool inUnitBounds(Vector3Int worldPos)
    {
        if (worldPos.x >= start.x && worldPos.x < end.x)
        {
            if (worldPos.y >= start.y && worldPos.y < end.y)
                return true;
        }
        return false;
    }

    private void initArray<T>(ref T[] array) => array = new T[unitTotalCount];

    public Unit(Vector3Int unitStartPos)
    {
        this.start = unitStartPos;

        initArray(ref units);
        initArray(ref unitPositions);
    }
}
