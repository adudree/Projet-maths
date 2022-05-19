using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidScoreColor : MonoBehaviour
{

    Color neutralColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
    Color currentColor; 
    int maxFriendshipScore = 10; //les points d'amitié vont de -10 à 10
    float colorStep; 
    int friendshipScore = 0;

    public int getFriendshipScore()
    {
        return friendshipScore; 
    }

    public void addFriendshipPoint()
    {
        if(friendshipScore < maxFriendshipScore)
        {
            friendshipScore++;
            currentColor.g += colorStep;
            currentColor.r -= colorStep;
        }
    }

    public void removeFriendshipPoint()
    {
        if (friendshipScore > -maxFriendshipScore)
        {
            friendshipScore--;
            currentColor.g -= colorStep;
            currentColor.r += colorStep;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = neutralColor;
        currentColor = neutralColor;
        colorStep = 2.0f/ ((float)maxFriendshipScore * 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(neutralColor, friendshipColor, Time.time/(float)5.0);
        gameObject.GetComponent<SpriteRenderer>().color = currentColor;
        
/*
        if (Input.GetMouseButtonDown(0))
        {
            //Left Mouse Button
            removeFriendshipPoint();
           // Debug.Log("my friendShip score is decreasing : " + friendshipScore);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //Right Mouse Button
            addFriendshipPoint();
           // Debug.Log("my friendShip score is increasing : " + friendshipScore);
        }*/

    }
}
