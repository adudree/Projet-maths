using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSoberScore : MonoBehaviour
{
    public GameObject characterBody;

    float maxSobrietyHeight = 0.75f;
    int maxSobrietyScore = 10;
    float heightStep;
    float currentHeight;
    int sobrietyScore;
    int liquidDrinkAtTheBeginning = 0; //number of sobriety points already gone when the game begins

    public void addSobrietyPoint()
    {
        if (sobrietyScore < maxSobrietyScore)
        {
            sobrietyScore++;
            currentHeight += heightStep;
        }
        characterBody.GetComponent<alcoholEffects>().updateSobrietyScore(sobrietyScore);
    }

    public void removeSobrietyPoint()
    {
        if (sobrietyScore > 0)
        {
            sobrietyScore--;
            currentHeight -= heightStep;
        }
        characterBody.GetComponent<alcoholEffects>().updateSobrietyScore(sobrietyScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        heightStep = maxSobrietyHeight / (float)maxSobrietyScore;
        currentHeight = maxSobrietyHeight - liquidDrinkAtTheBeginning * heightStep;
        sobrietyScore = maxSobrietyScore - liquidDrinkAtTheBeginning;
        characterBody.GetComponent<alcoholEffects>().updateSobrietyScore(sobrietyScore);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 local = transform.localScale;
        transform.localScale = new Vector3(local.x, currentHeight, local.z);

/*
        float scroll = Input.mouseScrollDelta.y;
        if (scroll > 0)
        {
            addSobrietyPoint();
        }
        else if (scroll < 0)
        {
            removeSobrietyPoint();
        }*/

    }
}
