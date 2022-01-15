using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    public int PlayerAreaType;
    //public string terrainType;
    //public string propType;
    //public string unitType;
    //public string effectType;
    [SerializeField] private GameObject _highlight;

    [SerializeField] private Sprite _grass, _fertileGrass, _dryGrass, _dirt;
    [SerializeField] private SpriteRenderer _tileRenderer;

    [SerializeField] private Color _white, _blue, _red;
    [SerializeField] private SpriteRenderer _highlightRenderer;
    [SerializeField] private UnitData _unit;



    public void SetTileType(int tileType)
    {
        switch (tileType)
        {
            case 0:
                _tileRenderer.sprite = _dirt;
                break;

            case 1:
                _tileRenderer.sprite = _dryGrass;
                break;

            case 2:
                _tileRenderer.sprite = _grass;
                break;

            case 3:
                _tileRenderer.sprite = _fertileGrass;
                break;

            default:
                _tileRenderer.sprite = _dirt;
                break;
        }

        
    }

    public int SetPlayerAreaType(int PlayerAreaType)
    {
        switch (PlayerAreaType)
        {
            case 0:
                _highlightRenderer.color = _white;
                break;

            case 1:
                _highlightRenderer.color = _red;
                break;

            case 2:
                _highlightRenderer.color = _blue;
                break;

            default:
                _highlightRenderer.color = _white;
                break;
        }

        return PlayerAreaType;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        _unit.IsAlive(PlayerAreaType);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    } 
}