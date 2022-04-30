using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class GameController : MonoBehaviour
{
    // Scriptable Objects

    // Call Backs

    // Managers


    // Controllers
    [SerializeField] private UnitManager unitManager;

    // Tile Maps
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Tilemap unitMap;

    // Data Structures

    // Variables
    private Vector3Int curPos;

    public int numPlayers = 1;

    public float secondsBetweenIterations = 0.15f;
    public int numInterationsPerRound = 144;
    public int iteration = 0;

    public int minute = 0;
    public int hour = 8;
    public int day = 0;
    public int week = 0;
    public int month = 0;
    public int year = 0;

    // Miscellaneous
    [SerializeField] TextMeshProUGUI timeText;
    // [SerializeField] TextMeshProUGUI PopText;

    // Awake
    private void Awake()
    {
        new WaitForSeconds(secondsBetweenIterations);

        //for (int p = 0; p <= numPlayers; p++)
        //{

        //}
    }

    // Start
    void Start()
    {
        int unitZ = Mathf.FloorToInt(unitMap.transform.position.z);

        Time.timeScale = 0;
        Debug.Log("Paused");

        StartCoroutine(MainXYLoop(iteration, unitZ));

    }

    // Update
    private void Update()
    {
        PlayPauseGame();
    }

    private void PlayPauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;

            if (Time.timeScale == 0) Debug.Log("Paused");
            else Debug.Log("Playing");
        }
    }

    IEnumerator MainXYLoop(int iteration, int unitZ)
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenIterations);

            if (Time.timeScale != 0) CountIterations();

            // First loop - Set Data
            for (int x = 0; x < tileMap.size.x; x++)
            {
                for (int y = 0; y < tileMap.size.y; y++)
                {
                    curPos.x = x;
                    curPos.y = y;
                    curPos.z = unitZ;

        
                    unitManager.SetData(curPos);
                }
            }

            // Second loop - Set Data
            for (int x = 0; x < tileMap.size.x; x++)
            {
                for (int y = 0; y < tileMap.size.y; y++)
                {
                    curPos.x = x;
                    curPos.y = y;
                    curPos.z = unitZ;

                    unitManager.SetLife(curPos);
                }
            }

            iteration++;

            if (iteration == numInterationsPerRound)
            {
                Time.timeScale = 0;
                iteration = 0;
            }
        }
    }

    void CountIterations()
    {
        minute += 10;
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

        timeText.SetText("Time: " + year + ":" + month + ":" + week + ":" + day + ":" + hour + ":" + minute);
    }

    
}