using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class UnitManager : MonoBehaviour
{
    // Scriptable Objects
    [SerializeField] private WorldUnits_SO worldUnits;

    // Call Backs

    // Classes
    private GameOfLifeAutomata gameOfLifeAutomata;
    public GameOfLifeAutomata getGameOfLifeAutomata => gameOfLifeAutomata;

    // Managers

    // Controllers
    [SerializeField] private WorldController worldController;

    // Tile Maps
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Tilemap unitMap;

    //Data Structures
    [SerializeField] private List<Tile> units = null;
    private int[,] unitLifeData;

    // Variables
    private int unitCount = 0;

    // Miscellaneous
    [SerializeField] TextMeshProUGUI PopText;

    // Awake
    private void Awake()
    {
        gameOfLifeAutomata = new GameOfLifeAutomata();

    }

    // Start
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0);

        unitLifeData = new int[worldController.getWorldSizeInChunks.x * worldController.getChunkSizeInTiles,
                               worldController.getWorldSizeInChunks.y * worldController.getChunkSizeInTiles];


        Debug.Log(worldController.getWorldSizeInChunks.x * worldController.getChunkSizeInTiles + " " +
                  worldController.getWorldSizeInChunks.x * worldController.getChunkSizeInTiles);
    }

    public void SetData(Vector3Int pos)
    {
        int numNeighbors = gameOfLifeAutomata.CountNeighbors(unitMap, pos);
        SetLifeData(numNeighbors, pos);
    }

    public void SetLifeData(int neighbors, Vector3Int pos)
    {
        // int unitCount = 0;

        // Debug.Log(pos);
        if (unitMap.HasTile(pos) && neighbors != 2 && neighbors != 3)
        {
            // unitCount--;
            unitLifeData[pos.x, pos.y] = 0;
        }

        else if (!unitMap.HasTile(pos) && neighbors == 3)
        {
            // unitCount++;
            unitLifeData[pos.x, pos.y] = 1;
        }

        else if (unitMap.HasTile(pos) && (neighbors == 2 || neighbors == 3)) unitLifeData[pos.x, pos.y] = 1;

        // else unitLifeData[pos.x, pos.y] = 0;

    }

    public void SetLife(Vector3Int pos)
    {
        if (unitLifeData[pos.x, pos.y] == 0) unitMap.SetTile(pos, null);

        else if (unitLifeData[pos.x, pos.y] == 1) unitMap.SetTile(pos, units[0]);
    }

    public void SetUnit(Vector3Int pos)
    {
        if (!unitMap.HasTile(pos))
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

    //private void SetUnit(Vector3Int tilePos, RootUnit_SO rootUnit)
    //{
    //    unitManager.SetUnit(tilePos, rootUnit);
    //}
}
