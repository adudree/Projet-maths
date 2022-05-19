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
                image.sprite = dragonFire;
            }
            if (name == "Data Occultist")
            {
                image.sprite = dataOccultist;
            }
            if (name == "Innkeeper")
            {
                image.sprite = innkeeperFire;
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
