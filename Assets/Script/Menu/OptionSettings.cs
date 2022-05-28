using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSettings : MonoBehaviour
{
    [SerializeField] Slider temperature;
    [SerializeField] Slider relationship;
    [SerializeField] Slider negociation;
    [SerializeField] Slider cooking;
    [SerializeField] GameObject randomVariables;

    public void SaveParameter(string param)
    {
        float value = 0;
        switch (param)
        {
            case "temperature":
                value = temperature.value;
                initDessert(value);
                break;
            case "relationship":
                value = relationship.value;
                break;
            case "negociation":
                value = negociation.value;
                break;
            case "cooking":
                value = cooking.value;
                break;
            default:
                break;
        }
        PlayerPrefs.SetFloat(param, value);
    }

    public void initDessert(float param)
    {
        string[] values = { "Ice cream", "Creme brulee" };
        string finalValue;

        if (!randomVariables.GetComponent<RandomVariables>().BernoulliLaw(param))
        {
            finalValue = values[0];
        }
        else { finalValue = values[1]; }

        PlayerPrefs.SetString("dessert", finalValue);
    }
}
