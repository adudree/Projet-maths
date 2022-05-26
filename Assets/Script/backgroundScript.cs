using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    [SerializeField] Sprite hostel;
    [SerializeField] Sprite entrance;
    [SerializeField] Sprite classroomIce;
    [SerializeField] Sprite classroomFire;
    [SerializeField] Sprite corridor;
    [SerializeField] Sprite DataOroom;
    [SerializeField] Sprite bossRoomFire;
    [SerializeField] Sprite bossRoomIce;

    [SerializeField] GameObject table;

    public void changeBackground(string room)
    {

        string dessert = PlayerPrefs.GetString("dessert");

        switch (room)
        {
            case "hostel":
                gameObject.GetComponent<SpriteRenderer>().sprite = hostel;
                break;
            case "entrance":
                gameObject.GetComponent<SpriteRenderer>().sprite = entrance;
                table.SetActive(false);
                break;
            case "classroom":
                setFireOrIceBG(classroomFire, classroomIce, dessert); 
                break;
            case "corridor":
                gameObject.GetComponent<SpriteRenderer>().sprite = corridor;
                break;
            case "bossRoom":
                setFireOrIceBG(bossRoomFire, bossRoomIce, dessert); 
                break;
            case "dataO":
                gameObject.GetComponent<SpriteRenderer>().sprite = DataOroom;
                break;
            default:
                break;
        }
    }

    void setFireOrIceBG(Sprite fire, Sprite ice, string dessert) {
        if (dessert == "Ice cream") {
            gameObject.GetComponent<SpriteRenderer>().sprite = ice;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().sprite = fire;
        }
    }

}
