using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    public Sprite hostel;
    public Sprite entrance;
    public Sprite classroom;
    public Sprite corridor;
    public Sprite DataOroom;
    public Sprite bossRoom;


    public void changeBackground(string room)
    {
        Debug.Log("newroom : " + room);
        switch (room) {
            case "hostel": 
                gameObject.GetComponent<SpriteRenderer>().sprite = hostel;
                break;
            case "entrance": 
                gameObject.GetComponent<SpriteRenderer>().sprite = entrance;
                break; 
            case "classroom": 
                gameObject.GetComponent<SpriteRenderer>().sprite = classroom;
                break; 
            case "corridor": 
                gameObject.GetComponent<SpriteRenderer>().sprite = corridor;
                break;
            case "bossRoom":
                gameObject.GetComponent<SpriteRenderer>().sprite = bossRoom;
                break;
            case "dataO":
                gameObject.GetComponent<SpriteRenderer>().sprite = DataOroom;
                break; 
            default: 
                break;
        }
    }


}
