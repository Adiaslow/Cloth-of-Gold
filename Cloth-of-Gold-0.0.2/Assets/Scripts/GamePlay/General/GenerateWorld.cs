// GOOD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private TileMapGenerator _tileMapGenerator;
    [SerializeField] private PropManager _propManager;
    [SerializeField] private NonplayerUnitManager _nonplayerUnitManager;

    [SerializeField] private int WORLDWIDTH = 100;
    [SerializeField] private int WORLDHEIGHT = 100;


    // Start is called before the first frame update
    void Start()
    {
        SetWorldSize(WORLDWIDTH, WORLDHEIGHT);
        GenerateTerrain();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetWorldSize(int _width, int _height)
    {
        _gridGenerator.SetGridWidth(_width);
        // Debug.Log("World Width Set to " + _width.ToString());

        _gridGenerator.SetGridHeight(_height);
        // Debug.Log("World Height Set to " + _height.ToString());

        Debug.Log("World Size Set to " + $"({_width}, {_height})");

    }

    private void GenerateTerrain()
    {
        _tileMapGenerator.GenerateTerrain();
    }
}
