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

    public GameObject randomVariables;
    int colorState = 0;

    public void changeBackground(string room)
    {
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
            case "secondCorridor": 
                gameObject.GetComponent<SpriteRenderer>().sprite = corridor;
                break;
            case "bossRoom":
                gameObject.GetComponent<SpriteRenderer>().sprite = bossRoom;
                break;
            case "DataO":
                gameObject.GetComponent<SpriteRenderer>().sprite = DataOroom;
                break; 
            default: 
                break;
        }
    }

    IEnumerator changeColorRegularly()
    {
        colorState = randomVariables.GetComponent<RandomVariables>().MarkovChainRGB(colorState);
        Debug.Log("state = " + colorState);
        float colorRandom = randomVariables.GetComponent<RandomVariables>().uniformLaw(0f, 1f);
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color[colorState] = colorRandom;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(3f);
        StartCoroutine(changeColorRegularly());
    }

    public void stroboColors()
    {
        StartCoroutine(changeColorRegularly());
    }
}
