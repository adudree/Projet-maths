using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPicture : MonoBehaviour
{
    public Sprite dwarf;
    public Sprite dragonFire;
    public Sprite dragonIce;
    public Sprite dataOccultist;
    public Sprite innkeeperIce;
    public Sprite innkeeperFire;
    Image image;

    public void setCharacterPicture(string name)
    {
        string dessert = PlayerPrefs.GetString("dessert");

        image = this.GetComponent<Image>();
        var tempColor = image.color;
        
        if (name == "Bottle")
        {
            tempColor.a = 0f;
            image.color = tempColor;
        } else
        {
            tempColor.a = 1f;
            image.color = tempColor;
            if (name == "Me")
            {
                image.sprite = dwarf;
            }
            if (name == "Teacher")
            {
                if (dessert == "Ice cream")
                {
                    image.sprite = dragonIce;
                } else
                {
                    image.sprite = dragonFire;
                }
            }
            if (name == "Data Occultist")
            {
                image.sprite = dataOccultist;
            }
            if (name == "Innkeeper")
            {
                if (dessert == "Ice cream")
                {
                    image.sprite = innkeeperIce;
                } else
                {
                    image.sprite = innkeeperFire;
                }
            }
        }


        
        
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
