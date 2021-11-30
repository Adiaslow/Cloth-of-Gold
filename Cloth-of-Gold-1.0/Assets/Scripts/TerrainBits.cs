using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBits : MonoBehaviour
{
    private static int SCREEN_WIDTH = 240;
    private static int SCREEN_HEIGHT = 135;
    private static int OFFSET_WIDTH = 6;
    private static int OFFSET_TOP_HEIGHT = 14;
    private static int OFFSET_BOTTOM_HEIGHT = 22;


    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {

        //Grass
        GameObject referenceTile1 = (GameObject)Instantiate(Resources.Load("Prefabs/SmallGrass1"));
        GameObject referenceTile2 = (GameObject)Instantiate(Resources.Load("Prefabs/MediumGrass1"));
        GameObject referenceTile3 = (GameObject)Instantiate(Resources.Load("Prefabs/MediumGrass2"));

        //Rocks
        GameObject referenceTile4 = (GameObject)Instantiate(Resources.Load("Prefabs/SmallRock1"));
        GameObject referenceTile5 = (GameObject)Instantiate(Resources.Load("Prefabs/MediumRock1"));

        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                if (!(x <= OFFSET_WIDTH || x - 1 >= SCREEN_WIDTH - OFFSET_WIDTH - 1 || y <= OFFSET_BOTTOM_HEIGHT - 1 || y - 1 >= SCREEN_HEIGHT - OFFSET_TOP_HEIGHT - 1))
                {
                    if (RandomTerrainPopulate() == true)
                    {
                        if (RandomTerrainType() == 0)
                        {
                            GameObject tile = (GameObject)Instantiate(referenceTile1, transform);

                            float posX = x;
                            float posY = y;

                            tile.transform.position = new Vector3(posX, posY);
                        }

                        else if (RandomTerrainType() == 1)
                        {
                            GameObject tile = (GameObject)Instantiate(referenceTile2, transform);

                            float posX = x;
                            float posY = y;

                            tile.transform.position = new Vector3(posX, posY);
                        }

                        else if (RandomTerrainType() == 2)
                        {
                            GameObject tile = (GameObject)Instantiate(referenceTile3, transform);

                            float posX = x;
                            float posY = y;

                            tile.transform.position = new Vector3(posX, posY);
                        }

                        else if (RandomTerrainType() == 3)
                        {
                            GameObject tile = (GameObject)Instantiate(referenceTile4, transform);

                            float posX = x;
                            float posY = y;

                            tile.transform.position = new Vector3(posX, posY);
                        }

                        else if (RandomTerrainType() == 4)
                        {
                            GameObject tile = (GameObject)Instantiate(referenceTile5, transform);

                            float posX = x;
                            float posY = y;

                            tile.transform.position = new Vector3(posX, posY);
                        }
                    }
                }
            }
        }

        Destroy(referenceTile1);
        Destroy(referenceTile2);
        Destroy(referenceTile3);
        Destroy(referenceTile4);
        Destroy(referenceTile5);
    }

    bool RandomTerrainPopulate()
    {
        int rand = UnityEngine.Random.Range(0, 100);

        if (rand > 98)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    int RandomTerrainType()
    {
        int rand = UnityEngine.Random.Range(0, 5);

        if (rand == 0)
        {
            return 0;
        }

        if (rand == 1)
        {
            return 1;
        }

        if (rand == 2)
        {
            return 2;
        }

        if (rand == 3)
        {
            return 3;
        }

        if (rand == 4)
        {
            return 4;
        }

        else
        {
            return 5;
        }
    }

}
