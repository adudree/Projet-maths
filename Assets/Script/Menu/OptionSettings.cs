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

    public void SaveParameter(string param) {
        float value = 0;

        switch (param) {
            case "temperature":
            value = temperature.value;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
