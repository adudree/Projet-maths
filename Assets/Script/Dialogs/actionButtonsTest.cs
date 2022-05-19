using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionButtonsTest : MonoBehaviour
{
    public GameObject waterDrop;
    public GameObject background;
    public GameObject randomVariables;
    public GameObject liquidBeer;
    public GameObject dialogManager;

    //Les fonctions doivent retourner true si après l'action le dialogue continue normalement, 
    //et false pour gérer elle même l'appel au dialogStep suivant (en bloquant le dialogManager). 

    public bool none() { return true; }

    public bool enterClassroom()
    {
        Debug.Log("You enter the classroom.");
        background.GetComponent<backgroundScript>().changeBackground("classroom");
        waterDrop.SetActive(false);
        return true;
    }

    public bool enterSecondCorridor()
    {
        Debug.Log("You enter the second corridor.");
        background.GetComponent<backgroundScript>().changeBackground("secondCorridor");
        return true;
    }

    public bool winFriendshipDoingClown()
    {
        float negociationSkills = 0.3f; //A remplacer par un paramètre défini par le joueur
        int nbSentencesBeforeEscape = randomVariables.GetComponent<RandomVariables>().geometricLaw(negociationSkills);
        for (int i = 0; i < nbSentencesBeforeEscape; i++)
        {
            liquidBeer.GetComponent<LiquidScoreColor>().addFriendshipPoint();
        }
        Debug.Log("doing Clown, you have won " + nbSentencesBeforeEscape + " friendship points !");
        enterSecondCorridor();
        return true;
    }

    public bool loseFriendshipDoingPrevention()
    {
        float negociationSkills = 0.3f; //A remplacer par un paramètre défini par le joueur
        int nbSentencesBeforeEscape = randomVariables.GetComponent<RandomVariables>().geometricLaw(negociationSkills);
        for (int i = 0; i < nbSentencesBeforeEscape; i++)
        {
            liquidBeer.GetComponent<LiquidScoreColor>().removeFriendshipPoint();
        }
        Debug.Log("doing prevention, you have lost " + nbSentencesBeforeEscape + " friendship points !");
        enterSecondCorridor();
        return true;
    }

    public bool enterBossRoom()
    {
        Debug.Log("You enter the boss room.");
        background.GetComponent<backgroundScript>().changeBackground("bossRoom");
        return true;
    }

    public bool tryFrienshipToTellSecret()
    {
        int friendshipScore = liquidBeer.GetComponent<LiquidScoreColor>().getFriendshipScore();
        Debug.Log("your friendship score is " + friendshipScore);
        if (friendshipScore >= 5)
        {
            dialogManager.GetComponent<DialogManager>().changeStep(12);
        } else
        {
            dialogManager.GetComponent<DialogManager>().changeStep(11);
        }
        return false;
    }

    public bool enterDataOccultistRoom()
    {
        Debug.Log("You enter the Data Occultist room.");
        background.GetComponent<backgroundScript>().changeBackground("DataO");
        background.GetComponent<backgroundScript>().stroboColors();
        return true;
    }
}