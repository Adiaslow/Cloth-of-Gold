using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static int SCREEN_WIDTH = 240;
    private static int SCREEN_HEIGHT = 135;
    private static int OFFSET_WIDTH = 6;
    private static int OFFSET_TOP_HEIGHT = 14;
    private static int OFFSET_BOTTOM_HEIGHT = 22;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        //GenerateRed();
    }

    private void GenerateGrid()
    {

        //Water
        GameObject referenceTile2 = (GameObject)Instantiate(Resources.Load("Prefabs/WaterBottom"));
        GameObject referenceTile3 = (GameObject)Instantiate(Resources.Load("Prefabs/WaterBottomLeft"));
        GameObject referenceTile4 = (GameObject)Instantiate(Resources.Load("Prefabs/WaterLeft"));
        GameObject referenceTile5 = (GameObject)Instantiate(Resources.Load("Prefabs/WaterTopLeft"));
        GameObject referenceTile6 = (GameObject)Instantiate(Resources.Load("Prefabs/WaterTop"));
        GameObject referenceTile7 = (GameObject)Instantiate(Resources.Load("Prefabs/WaterTopRight"));
        GameObject referenceTile8 = (GameObject)Instantiate(Resources.Load("Prefabs/WaterRight"));
        GameObject referenceTile9 = (GameObject)Instantiate(Resources.Load("Prefabs/WaterBottomRight"));

        //Grass
        GameObject referenceTile10 = (GameObject)Instantiate(Resources.Load("Prefabs/GrassCenter"));


        //Terrain
        for (int x = 0; x < SCREEN_WIDTH; x++)
        {
            for (int y = 0; y < SCREEN_HEIGHT; y++)
            {
                //North Edge
                if (y == SCREEN_HEIGHT - OFFSET_TOP_HEIGHT & x > OFFSET_WIDTH & x < SCREEN_WIDTH - OFFSET_WIDTH)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile6, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }

                //South Edge
                if (y == OFFSET_BOTTOM_HEIGHT - 1 & x > OFFSET_WIDTH & x < SCREEN_WIDTH - OFFSET_WIDTH)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile2, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }

                //East Edge
                if (x == OFFSET_WIDTH & y > OFFSET_BOTTOM_HEIGHT - 1 & y < SCREEN_HEIGHT - OFFSET_TOP_HEIGHT)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile4, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }

                //West Edge
                if (x == SCREEN_WIDTH - OFFSET_WIDTH & y > OFFSET_BOTTOM_HEIGHT - 1 & y < SCREEN_HEIGHT - OFFSET_TOP_HEIGHT)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile8, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }

                //North West Edge
                if (x == OFFSET_WIDTH & y == SCREEN_HEIGHT - OFFSET_TOP_HEIGHT)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile5, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }

                //North East Edge
                if (x == SCREEN_WIDTH - OFFSET_WIDTH & y == SCREEN_HEIGHT - OFFSET_TOP_HEIGHT)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile7, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }

                //South West Edge
                if (x == OFFSET_WIDTH & y == OFFSET_BOTTOM_HEIGHT - 1)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile3, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }

                //South East Edge
                if (x == SCREEN_WIDTH - OFFSET_WIDTH & y == OFFSET_BOTTOM_HEIGHT - 1)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile9, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }



                //Grass
                if (x > OFFSET_WIDTH & x < SCREEN_WIDTH - OFFSET_WIDTH & y > OFFSET_BOTTOM_HEIGHT - 1 & y < SCREEN_HEIGHT - OFFSET_TOP_HEIGHT)
                {
                    GameObject tile = (GameObject)Instantiate(referenceTile10, transform);

                    float posX = x;
                    float posY = y;
                    float posZ = -10;

                    tile.transform.position = new Vector3(posX, posY, posZ);
                }
            }
        }

        Destroy(referenceTile2);
        Destroy(referenceTile3);
        Destroy(referenceTile4);
        Destroy(referenceTile5);
        Destroy(referenceTile6);
        Destroy(referenceTile7);
        Destroy(referenceTile8);
        Destroy(referenceTile9);
        Destroy(referenceTile10);
    }
}