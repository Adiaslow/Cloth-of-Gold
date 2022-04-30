using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap = null;
    [SerializeField] private Tilemap unitMap = null;
    [SerializeField] private Tilemap cursorMap = null;
    [SerializeField] private List<Tile> cursors = null;
    [SerializeField] private UnitManager unitManager;

    private Vector3Int previousMousePos = new Vector3Int();
    private Vector3Int mousePos = new Vector3Int();

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = GetMousePosition();

        bool mouseOverUI = IsOverUI();

        Cursor(mousePos, mouseOverUI);
        LeftClick(mousePos, mouseOverUI);
        RightClick(mousePos, mouseOverUI);
    }

    private Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return tileMap.WorldToCell(new Vector3Int(Mathf.FloorToInt(mouseWorldPos.x), Mathf.FloorToInt(mouseWorldPos.y), 0));
    }

    private void Cursor(Vector3Int mousePos, bool mouseOverUI)
    {
        if (mouseOverUI) cursorMap.SetTile(previousMousePos, null);

        else if (!mousePos.Equals(previousMousePos))
        {
            cursorMap.SetTile(previousMousePos, null); // Remove old hoverTile
            cursorMap.SetTile(mousePos, cursors[0]);
            previousMousePos = mousePos;
        }
    }

    private void LeftClick(Vector3Int mousePos, bool mouseOverUI)
    {
        // Left mouse click -> add path tile
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 0)
        {
            unitManager.SetUnit(new Vector3Int(mousePos.x, mousePos.y, Mathf.FloorToInt(unitMap.transform.position.z)));
        }
    }

    private void RightClick(Vector3Int mousePos, bool mouseOverUI)
    {
        // Right mouse click
        if (Input.GetMouseButtonDown(1) && Time.timeScale == 0)
        {
            if (unitMap.HasTile(new Vector3Int(mousePos.x, mousePos.y, mousePos.z)))
            {
                Debug.Log(unitMap.GetTile(new Vector3Int(mousePos.x, mousePos.y, mousePos.z)).name + ", " +
                                                         tileMap.GetTile(new Vector3Int(mousePos.x, mousePos.y, 0)).name);
                //unitManager.unitCount--;
                //Debug.Log(unitManager.unitCount);
            }

            else Debug.Log(tileMap.GetTile(new Vector3Int(mousePos.x, mousePos.y, 0)).name);
        }
    }

    private bool IsOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}