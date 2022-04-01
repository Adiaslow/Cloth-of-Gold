using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap = null;
    [SerializeField] private List<Tile> hoverTiles = null;
    [SerializeField] private UnitManager unitManager = null;
    [SerializeField] private UnitController unitController = null;

    [SerializeField] private Tilemap unitMap = null;
    [SerializeField] private List<Tile> units = null;

    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos))
        {
            tileMap.SetTile(previousMousePos, null); // Remove old hoverTile
            tileMap.SetTile(mousePos, hoverTiles[0]);
            previousMousePos = mousePos;
        }

        Vector3Int unitPos = new Vector3Int(mousePos.x, mousePos.y, mousePos.z - mousePos.y);

        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0))
        {
            unitMap.SetTile(unitPos, units[0]);
            
        }

        // Right mouse click -> remove path tile
        if (Input.GetMouseButton(1))
        {
            unitMap.SetTile(unitPos, null);
        }
    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TileBase tileBase = tileMap.GetTile(new Vector3Int(Mathf.FloorToInt(mouseWorldPos.x), Mathf.FloorToInt(mouseWorldPos.y), Mathf.FloorToInt(mouseWorldPos.z)));
        return tileMap.WorldToCell(mouseWorldPos);
    }
}