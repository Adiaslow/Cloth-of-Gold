using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDimensions
    {
    int NUM_SECTORS;
    int SECTOR_SIZE;

    public MapDimensions()
    {
        NUM_SECTORS = 2;
        SECTOR_SIZE = 8;
    }
}

public static class MapExtensions
{
    public static Dictionary<string, float>  GetMapDimensions(this int NUM_SECTORS, int SECTOR_SIZE)
    {
        Dictionary<string, float> mapDimensions = new Dictionary<string, float>();

        int WIDTH = 0;
        int HEIGHT = 0;

        if (NUM_SECTORS == 0)
        {
            WIDTH = HEIGHT = 0;
        }

        else if (NUM_SECTORS % 2 != 0)
        {
            WIDTH = SECTOR_SIZE * NUM_SECTORS;
        }

        else
        {
            WIDTH = SECTOR_SIZE * NUM_SECTORS;
            HEIGHT = SECTOR_SIZE * NUM_SECTORS / 2;
        }

        mapDimensions.Add("mapWidth", WIDTH);
        mapDimensions.Add("mapHeight", HEIGHT);

        return mapDimensions;
    }
}
