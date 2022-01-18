using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayPause()
    {
        if (Time.timeScale == 0)
        {
            GameObject.Find("PlayPause").GetComponentInChildren<Text>().text = "Pause";

            Time.timeScale = 1;

            
        }

        else
        {
            GameObject.Find("PlayPause").GetComponentInChildren<Text>().text = "Play";

            Time.timeScale = 0;
        }
    }
}
