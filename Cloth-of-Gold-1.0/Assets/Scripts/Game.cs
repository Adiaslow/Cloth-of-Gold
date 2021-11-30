using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Game : MonoBehaviour
{
    private static int SCREEN_WIDTH = 240;
    private static int SCREEN_HEIGHT = 135;
    private static int OFFSET_WIDTH = 5;
    private static int OFFSET_TOP_HEIGHT = 17;
    private static int OFFSET_BOTTOM_HEIGHT = 21;
    private static int ORDER = 10;


    public int popPercent = 50;


    [SerializeField] public float speed = 0.2f;
    [SerializeField] public float speedInterval = 0.2f;
    [SerializeField] public float speedMin = 0f; // Lower = Faster
    [SerializeField] public float speedMax = 1f; // Higher = Slower

    public int iteration = -1;


    public int minute;
    public int hour;
    public int day;
    public int week;
    public int month;
    public int year;

    private float timer = 0;

    public int population;

    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    [SerializeField] TextMeshProUGUI iterationText;

    [SerializeField] TextMeshProUGUI populationText;



    



    // Start is called before the first frame update
    void Start()
    {
        PlaceCells();


    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= speed)
        {
            timer = 0f;

            CountNeighbors();

            PopulationControl();

            CountIterations();
        }

        else
        {
            timer += Time.deltaTime;
        }
    }

    public void Faster()
    {
        if (speed > speedMin && iteration != 0)
        {
            speed -= speedInterval;
        }
    }

    public void Slower()
    {
        if (speed < speedMax && iteration != 0)
        {
            speed += speedInterval;
        }
    }

    void PlaceCells()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                    Cell cell = Instantiate(Resources.Load("Prefabs/Cell", typeof(Cell)), new Vector3(x, y, ORDER), Quaternion.identity) as Cell;
                    grid[x, y] = cell;

                // grid[x, y].SetAlive(RandomAliveCell());
                
                if (!(x <= OFFSET_WIDTH + 1 || x - 1 >= SCREEN_WIDTH - OFFSET_WIDTH - 2 || y <= OFFSET_BOTTOM_HEIGHT || y - 1 >= SCREEN_HEIGHT - OFFSET_TOP_HEIGHT + 2))
                {
                    grid[x, y].SetAlive(RandomAliveCell());
                }
                else
                {
                    grid[x, y].SetAlive(false);
                }
                
            }
        }
    }

    void CountNeighbors()
    {
        population = 0;

        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                int numNeighbors = 0;

                // North
                if (y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //East
                if (x + 1 < SCREEN_WIDTH)
                {
                    if (grid[x + 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // South
                if (y - 1 >= 0)
                {
                    if (grid[x, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //West
                if (x - 1 >= 0)
                {
                    if (grid[x - 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //NorthEast
                if (x + 1 < SCREEN_WIDTH && y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x + 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //NorthWest
                if (x - 1 >= 0 && y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x - 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SouthEast
                if (x + 1 < SCREEN_WIDTH && y - 1 >= 0)
                {
                    if (grid[x + 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //SouthWest
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (grid[x - 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                grid[x, y].numNeighbors = numNeighbors;

                CountPopulation(x, y);
            }
        }
    }

    void PopulationControl ()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                // Rules
                // Any live cell with 2 or 3 live neighbors survives
                // Any dead cell with 3 live neighbors becomes a live cell
                // All other live cells die in the next generation and all other dead cells stay dead

                if (grid[x, y].isAlive)
                {
                    // Cell is Alive
                    if (grid[x, y].numNeighbors != 2 && grid[x, y].numNeighbors != 3)
                    {
                        grid[x, y].SetAlive(false);
                    }
                }

                    // Cell is Drowned
                if ((x <= OFFSET_WIDTH + 1 || x - 1 >= SCREEN_WIDTH - OFFSET_WIDTH - 2 || y <= OFFSET_BOTTOM_HEIGHT + 1 || y - 1 >= SCREEN_HEIGHT - OFFSET_TOP_HEIGHT + 2))
                {
                    if (grid[x, y].isAlive)
                    {
                        grid[x, y].SetAlive(false);
                    }
                }
                else
                {
                    // Cell is Dead
                    if (grid[x, y].numNeighbors == 3)
                    {
                        grid[x, y].SetAlive(true);
                    }
                }
            }
        }
    }

    bool RandomAliveCell()
    {
        int rand = UnityEngine.Random.Range(0, 100);

        if (rand > popPercent)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    void CountIterations()
    {
        iteration++;
        minute += 10;
        //Debug.Log(iteration);

        if (minute >= 60)
        {
            hour++;
            minute = 0;
        }

        if (hour >= 24)
        {
            day++;
            hour = 0;
        }

        if (day >= 7)
        {
            week++;
            day = 0;
        }

        if (week >= 4)
        {
            month++;
            week = 0;
        }

        if (month >= 12)
        {
            year++;
            month = 0;
        }

        iterationText.SetText(string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", minute) + " - D " + string.Format("{0:00}", day) + " - W " + string.Format("{0:00}", week) + " - M " + string.Format("{0:00}", month) + " - Y " + string.Format("{0:00}", year));
    }
    void CountPopulation(int x, int y)
    {
        if (grid[x, y].isAlive)
        {
            population++;
            //Debug.Log(population);
            populationText.SetText("Total Pop: " + string.Format("{0:00000}", population));
        }
    }
}
