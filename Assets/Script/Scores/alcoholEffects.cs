using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alcoholEffects : MonoBehaviour
{
    int sobrietyScore;
    Vector3 startPosition;

    public void updateSobrietyScore(int value)
    {
        sobrietyScore = value;
    }

    void shake()
    {
        float speedPosition = 2.0f; //how fast it shakes
        float amountPosition = 1.7f*1f/(sobrietyScore+1f); //how much it shakes
        float valuePosition = Mathf.Sin(Time.time * speedPosition) * amountPosition;
        Vector3 position = gameObject.GetComponent<Transform>().position;
        position.x = startPosition.x+ valuePosition;
        gameObject.GetComponent<Transform>().position = position;

        float speedRotation = 1f; //how fast it shakes
        float amountRotation = 0.005f; //how much it shakes
        float valueRotation = Mathf.Cos(Time.time * speedRotation) * amountRotation;
        gameObject.GetComponent<Transform>().Rotate(0f, 0f, valueRotation);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (sobrietyScore == 6)
        {
            startPosition = gameObject.GetComponent<Transform>().position;
        }
        if (sobrietyScore <= 5)
        {
            shake();
        }
    }
}
