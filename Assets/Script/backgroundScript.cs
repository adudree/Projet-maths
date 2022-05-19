using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    public Sprite corridor;
    public Sprite classroom;
    public Sprite corridor2;
    public Sprite DataOroom;
    public Sprite bossRoom;

    public GameObject randomVariables;
    int colorState = 0;

    public void changeBackground(string room)
    {
        if (room == "classroom")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = classroom;
        }
        if (room == "secondCorridor")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = corridor2;
        }
        if (room == "bossRoom")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bossRoom;
        }
        if (room == "DataO")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = DataOroom;
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
