using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fumee : MonoBehaviour
{

    public GameObject randomVariables;
    int colorState = 0;

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
