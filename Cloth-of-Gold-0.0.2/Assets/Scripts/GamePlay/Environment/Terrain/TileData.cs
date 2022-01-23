// GETTING BETTER

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _tileRenderer;
    [SerializeField] private Sprite _test, _dirt, _grass, _dryGrass, _fertileGrass;


    public string tileName { get; private set; }
    public int tilePosX { get; private set; }
    public int tilePosY { get; private set; }
    public Quaternion tileRot { get; private set; }

    public bool isInit { get; private set; } = false;

    public bool InitTile(int _tileType, string _tileName, int _tilePosX, int _tilePosY, Quaternion _tileRot)
    {
        bool _success = true;
        _success = this.SetTileType(_tileType);
        _success = this.SetTileName(_tileName);
        _success = this.SetTilePos(_tilePosX, _tilePosY);
        _success = this.SetTileRot(_tileRot);

        this.isInit = _success;

        return true;
    }

    public TileData GetTile()
    {
        TileData tileData = new TileData();
        return tileData;
    }

    public bool SetTileType(int tileType)
    {
        switch (tileType)
        {
            case 0:
                this._tileRenderer.sprite = _dirt;
                break;

            case 1:
                this._tileRenderer.sprite = _dryGrass;
                break;

            case 2:
                this._tileRenderer.sprite = _grass;
                break;

            case 3:
                this._tileRenderer.sprite = _fertileGrass;
                break;

            default:
                this._tileRenderer.sprite = _test;
                break;
        }

        return true;
    }

    public bool SetTileName(string tileName)
    {
        this.tileName = tileName;
        return true;
    }

    public bool SetTilePos(int x, int y)
    {
        this.tilePosX = x;
        this.tilePosY = y;
        return true;
    }

    public bool SetTileRot(Quaternion tileRot)
    {
        this.tileRot = tileRot;
        return true;
    }

    /*
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
  */
}