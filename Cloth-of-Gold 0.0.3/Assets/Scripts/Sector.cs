using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] public int SECTOR_SIZE = 8;

    private void Start()
    {
        transform.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(SECTOR_SIZE, SECTOR_SIZE);
    }

    public void TurnOnChildren() => this.gameObject.GetAllChilds().ForEach(x => x.SetActive(true));

    public void TurnOffChildren()=> this.gameObject.GetAllChilds().ForEach(x => x.SetActive(false));
}

public static class Extentions
{
    public static List<GameObject> GetAllChilds(this GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();

        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }

        return list;
    }
}

