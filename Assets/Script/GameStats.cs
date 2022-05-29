using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    public GameObject IceFireDetails;
    public GameObject IceFireDrawnValue;
    public GameObject IceFireExpectedValue;
    public GameObject IceFireStandardDeviation;
    public GameObject WaterPositionDrawnValue;
    public GameObject WaterTimeDrawnValue;
    public GameObject SentencesDetails;
    public GameObject SentencesDrawnValue;
    public GameObject SentencesExpectedValue;
    public GameObject SentencesStandardDeviation;
    public GameObject DessertsDetails;
    public GameObject DessertsDrawnValue;
    public GameObject DessertsExpectedValue;
    public GameObject DessertsStandardDeviation;
    public GameObject ColorAverageDraws;
    public GameObject ColorStandardDeviationDraws;
    public GameObject LettersAverageDraws;
    public GameObject LettersStandardDeviationDraws;

    public GameObject colorObject;
    public GameObject nameObject;

    public void showStats()
    {
        FillArray();
        gameObject.SetActive(true);
        
    }

    void FillArray()
    {
        //Ice fire
        float paramIceFire = PlayerPrefs.GetFloat("temperature", 0f);
        IceFireDetails.GetComponent<Text>().text = "Bernouilli Law, parameter = " + paramIceFire;
        string drawnIceFire = PlayerPrefs.GetString("dessert", "Creme brulee");
        int drawnIceFireNb = 1;
        if (drawnIceFire == "Creme brulee")
        {
            drawnIceFireNb = 1;
        } else
        {
            drawnIceFireNb = 0;
        }
        IceFireDrawnValue.GetComponent<Text>().text = drawnIceFireNb.ToString();
        IceFireExpectedValue.GetComponent<Text>().text = paramIceFire.ToString();
        IceFireStandardDeviation.GetComponent<Text>().text = Mathf.Sqrt(paramIceFire*(1- paramIceFire)).ToString();
        
        // Water Drop
        float waterPos = PlayerPrefs.GetFloat("positionWaterDrop", 0f);
        WaterPositionDrawnValue.GetComponent<Text>().text = waterPos.ToString();
        float waterTime = PlayerPrefs.GetFloat("timeWaterDrop", 0f);
        WaterTimeDrawnValue.GetComponent<Text>().text = waterTime.ToString();

        // Sentences

        float paramSentences = PlayerPrefs.GetFloat("negociation", 0.3f);
        SentencesDetails.GetComponent<Text>().text = "Geometric Law, parameter = " + paramSentences;
        int nbSentences = PlayerPrefs.GetInt("nbSentences", 0);
        SentencesDrawnValue.GetComponent<Text>().text = nbSentences.ToString();
        SentencesExpectedValue.GetComponent<Text>().text = (1f / paramSentences).ToString();
        float sentencesVariance = (1f / paramSentences) / (paramSentences * paramSentences);
        SentencesStandardDeviation.GetComponent<Text>().text = Mathf.Sqrt(sentencesVariance).ToString();

        // Number of desserts
        float paramDessert = PlayerPrefs.GetFloat("cooking", 0f);
        DessertsDetails.GetComponent<Text>().text = "Poisson Law, parameter = " + paramDessert;
        int nbDesserts = PlayerPrefs.GetInt("nbDessert", 0);
        DessertsDrawnValue.GetComponent<Text>().text = nbDesserts.ToString();
        DessertsExpectedValue.GetComponent<Text>().text = paramDessert.ToString();
        DessertsStandardDeviation.GetComponent<Text>().text = Mathf.Sqrt(paramDessert).ToString();

        // Colors
        List<float> colorsList = colorObject.GetComponent<Fumee>().ColorDraws;
        float colorsAverage = 0;
        foreach (float value in colorsList)
        {
            colorsAverage += value;
        }
        colorsAverage = colorsAverage / (float)colorsList.Count;
        ColorAverageDraws.GetComponent<Text>().text = colorsAverage.ToString() + " (" + colorsList.Count + " draws)";

        float colorsVariance = 0;
        foreach (float value in colorsList)
        {
            colorsVariance += (value - colorsAverage)*(value - colorsAverage);
        }
        colorsVariance = colorsVariance / (float)colorsList.Count;
        ColorStandardDeviationDraws.GetComponent<Text>().text = Mathf.Sqrt(colorsVariance).ToString();

        // Letters
        List<int> nameList = nameObject.GetComponent<RandomName>().RademacherDraws;
        float nameAverage = 0;
        foreach (float value in nameList)
        {
            nameAverage += value;
        }
        nameAverage = nameAverage / (float)nameList.Count;
        LettersAverageDraws.GetComponent<Text>().text = nameAverage.ToString() + " (" + nameList.Count + " draws)";

        float nameVariance = 0;
        foreach (float value in nameList)
        {
            nameVariance += (value - nameAverage) * (value - nameAverage);
        }
        nameVariance = nameVariance / (float)nameList.Count;
        LettersStandardDeviationDraws.GetComponent<Text>().text = Mathf.Sqrt(nameVariance).ToString();
        
    }
    
}
