using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAreaManager : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite[] blue;
    public Sprite[] red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BlueArea();
   
    }

    private void BlueArea()
    {
        IEnumerator Blue()
        {
            int i;
            i = 0;
            while (i < blue.Length)
            {
                spriteRenderer.sprite = blue[i];
                i++;
                yield return new WaitForSeconds(0.07f);
                yield return 0;

            }
            StartCoroutine(Blue());
        }
    }
}
