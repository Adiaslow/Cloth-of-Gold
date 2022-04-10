using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class GameOfLifeAutomata
{
    public GameOfLifeAutomata()
    {
        // _units = new List<Unit>();
    }

    public int CountNeighbors(Tilemap unitMap, Vector3Int pos)
    {
        int neighborCount = 0;

        if (unitMap.HasTile(new Vector3Int(pos.x - 1, pos.y - 1, pos.z))) neighborCount++; // down left
        if (unitMap.HasTile(new Vector3Int(pos.x - 1, pos.y + 1, pos.z))) neighborCount++; // up left
        if (unitMap.HasTile(new Vector3Int(pos.x + 1, pos.y - 1, pos.z))) neighborCount++; // down right
        if (unitMap.HasTile(new Vector3Int(pos.x + 1, pos.y + 1, pos.z))) neighborCount++; // up right
        if (unitMap.HasTile(new Vector3Int(pos.x - 1, pos.y, pos.z))) neighborCount++; // left
        if (unitMap.HasTile(new Vector3Int(pos.x + 1, pos.y, pos.z))) neighborCount++; // right
        if (unitMap.HasTile(new Vector3Int(pos.x, pos.y - 1, pos.z))) neighborCount++; // down
        if (unitMap.HasTile(new Vector3Int(pos.x, pos.y + 1, pos.z))) neighborCount++; // up

        return neighborCount;
    }

    public bool CheckHasUnit(Tilemap unitMap, Vector3Int pos)
    {
        if (unitMap.HasTile(pos)) return true;
        else return false;
    }

    public TileBase GetUnit(Tilemap unitMap, Vector3Int pos)
    {

        TileBase unit = unitMap.GetTile(pos);

        return unit;
    }

    /*
    public void SetUnit(Tilemap unitMap, Vector3Int pos)
    {
        if (!unitMap.HasTile(new Vector3Int(pos.x, pos.y, pos.z)))
        {
            unitMap.SetTile(pos, units[0]);
            Debug.Log("Unit count = " + unitCount);
            Debug.Log("Unit pos = " + pos);
        }

        else
        {
            unitMap.SetTile(pos, null);
            Debug.Log("Unit count = " + unitCount);
        }
    }
    */
}
