using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dessert : MonoBehaviour
{
    public Sprite[] spriteArray;

    public void setSprite()
    {
        if (PlayerPrefs.HasKey("dessert") && PlayerPrefs.GetString("dessert") == "Ice cream")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[0];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[1];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<dessert>().setSprite();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
