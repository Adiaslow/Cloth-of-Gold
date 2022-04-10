using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSectorManager : MonoBehaviour
{
    [SerializeField] private Tile _tile;

    [SerializeField] private Sector _sector;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Sector _sector))
        {
            _sector.TurnOnChildren();

            Debug.Log(col.name + " entered the camera.");
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent(out Sector _sector))
        {
            _sector.TurnOffChildren();

            Debug.Log(col.name + " exited the camera.");
        }

    }
}
