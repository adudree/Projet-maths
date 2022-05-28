using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Assertions;

public class RandomFunctions : MonoBehaviour
{

    bool CoinFlipping(float probabilityHead)
    {
        if (probabilityHead  <= 0f ||   probabilityHead >= 1f) {
            Debug.Log("WARNING : Probability must be between 0 and 1, here it is : " + probabilityHead);
        }

        float rand = Random.value;
        if (rand < probabilityHead)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    int randomFiniteSet(float[] probabilities)
    {
        float sumOfProbabilities = 0;
        foreach (float proba in probabilities)
        {
            sumOfProbabilities += proba;
        }
        if (Mathf.Abs(sumOfProbabilities-1) > 0.001)
        {
            Debug.Log("WARNING : Sum of Probabilities must be 1, here it is : "+sumOfProbabilities );
        }

        float rand = Random.value;
        Debug.Log("random number = "+rand);
        int result = 1;
        float sum = probabilities[0];
        while (sum <= rand && result < probabilities.Length)
        {
            sum += probabilities[result];
            result++;
        }
        return result;
    }

    float accidentalTime(float esperance)
    {
        float rand = Random.value;
        return -esperance * Mathf.Log(1 - rand);
    }


    // Start is called before the first frame update
    void Start()
    {

        float sum = 0;
        for (int i = 0; i < 1000; i++)
        {
            sum += accidentalTime(25);
        }
        Debug.Log("Mes temps aleatoires :" + sum/1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
