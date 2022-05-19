using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;


public class RandomDice : MonoBehaviour
{

    List<float> probas = new List<float> {1/4f, 1/8f, 1/2f, 1/7f};

    float dice(float myRandom) 
    {
        float n = 6f;
        for (int i = 0; i < n; i++) {
            if (myRandom <= (i+1)/n) {
                return i+1;
            }
        }
        return n;
    }

    float sumValues(List<float> myList) {
        float sum = 0; 
        foreach (float v in myList) {
            sum += v;
        }
        return sum;
    }

    List<float> addOneValue(List<float> myList) 
    {
        Debug.Log("Attention : la somme des probas ne vaut pas 1");
        myList.Add(1 - sumValues(myList));

        return myList;
    }

    float generalProba(float myRandom, List<float> probabilities) {
        float sum = 0; 

        for (int i = 0; i < probabilities.Count; i++) {

            // pour éviter le out of range 
            float max;
            if (i+1 == probabilities.Count) {max = 1;}
            else {max = sum + probabilities[i];}

            if (sum <= myRandom && myRandom <= max) {
                return i+1;
            }
            sum += probabilities[i];
        }

        return 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        float myRandom = Random.value;
        Debug.Log("Mon nombre random : " + myRandom);
        
        // Lancer le dé à 6 faces
        Debug.Log(dice(myRandom));

        // Lancer le dé à autant de faces qu'il y a de probas dans le tableau 
        if (sumValues(probas) != 1) probas = addOneValue(probas);   // Vérif : somme des P == 1
        Debug.Log(myRandom + "  |  " + generalProba(myRandom, probas));

    }

    // Update is called once per frame
    void Update()
    {
        // Restart with space (c pratique)
        if (Input.GetKeyDown("space")) {
            Start();
        }
    }
}