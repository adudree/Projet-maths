using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVariables : MonoBehaviour
{
    // Loi uniforme
    public float uniformLaw(float a, float b)
    {
        float rand = Random.value;
        return (b - a) * rand + a;
    }

    // 95% chances to get <= 5s with parameter = 0.599
    public float exponentialLaw(float parameter)
    {
        float rand = Random.value;
        return - (1f/parameter) * Mathf.Log(rand);
    }

    // Loi de Bernoulli 
    bool BernoulliLaw(float parameter)
    {
        if (parameter <= 0f || parameter >= 1f)
        {
            Debug.Log("WARNING : Probability must be between 0 and 1, here it is : " + parameter);
        }
        float rand = Random.value;
        return rand < parameter;
    }

    // Loi de Rademacher 
    public int rademacherLaw() {
        float rand = Random.value; 
        if (rand < 1/2f) return -1;
        else return 1; 
    }

    // Loi géométrique
    public int geometricLaw(float parameter)
    {
        int nbTrial = 1;
        while (!BernoulliLaw(parameter))
        {
            nbTrial++;
        }
        return nbTrial;
    }


    int randomFiniteSet(float[] probabilities)
    {
        float sumOfProbabilities = 0;
        foreach (float proba in probabilities)
        {
            sumOfProbabilities += proba;
        }
        if (Mathf.Abs(sumOfProbabilities - 1) > 0.001)
        {
            Debug.Log("WARNING : Sum of Probabilities must be 1, here it is : " + sumOfProbabilities);
        }

        float rand = Random.value;
        int result = 0;
        float sum = probabilities[0];
        while (sum <= rand && result < probabilities.Length)
        {
            sum += probabilities[result+1];
            result++;
        }
        return result;
    }

    // 0 = R, 1 = G, 2 = B
    public int MarkovChainRGB(int actualState)
    {
        float[] probaFromR = { 0.2f, 0.5f, 0.3f };
        float[] probaFromG = { 0.2f, 0.2f, 0.6f };
        float[] probaFromB = { 0.6f, 0.3f, 0.1f };
        
        float[][] probasDependingOnState = { probaFromR, probaFromG, probaFromB };
        Debug.Log("longueurs " + probasDependingOnState[actualState].Length);

        int nextState = randomFiniteSet(probasDependingOnState[actualState]);
        return nextState;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Pour v�rifier vers o� max la loi exponentielle tombe : 
        /*float valueSup5 = 0;
        for (int i = 0; i < 1000; i++)
        {
            if(exponentialLaw(0.599f) > 5f)
            {
                valueSup5++;
            }
        }
        Debug.Log("nombre fois sup 5 / 100 = " + valueSup5 / 10f);*/

        //Pour voir si la loi uniforme a l'air uniforme
        /*float moyenne = 0;
        for (int i = 0; i < 1000; i++)
        {
            moyenne += uniformLaw(0f, 100f);
        }
        Debug.Log("moyenne loi uniforme de 0 � 100 : " + moyenne / 1000f);*/
        }

    // Update is called once per frame
    void Update()
    {
    }
}
