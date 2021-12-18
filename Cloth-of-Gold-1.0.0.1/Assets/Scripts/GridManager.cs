using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int rows = 19;
    [SerializeField]
    private int cols = 22;
    [SerializeField]
    private float tileSize = 1f;

    enum GridType
    {
        Ground,
        Prop,
        Cell,
        Effect
    }

    
    private void Start()
    {
        // GenerateGride();
    }

    private void Grid()
    {
        int[,] groundGrid = new int[cols, rows];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int num = UnityEngine.Random.Range(0,1);

                groundGrid[row, col] = num;
            }
        }


    }

        /*
    private void GenerateGride()
    {
        GameObject testTile = (GameObject)Instantiate(Resources.Load("TestTile"));

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(testTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);

            }
        }

        Destroy(testTile);

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;

        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
    }
        */
}
