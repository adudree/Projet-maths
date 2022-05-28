using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;


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
    public bool BernoulliLaw(float parameter)
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

    public int PoissonLaw(float parameter) {
        float rand = Random.value;
        int x = 0;                          // variable aléatoire
        float y = Mathf.Exp(-parameter);    // fonction de répartition 
        float z = y;                        // valeur F(0) de la fonction de répartition
                                            // de la variable aléatoire en 0

        while (z < rand) {
            x++;
            y = y * parameter / x; 
            z += y;
        }
        return x; 
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

        int nextState = randomFiniteSet(probasDependingOnState[actualState]);
        return nextState;
    }

}
