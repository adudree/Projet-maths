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
    public GameObject fumee;

    //Les fonctions doivent retourner true si apres l'action le dialogue continue normalement, 
    //et false pour gerer elle meme l'appel au dialogStep suivant (en bloquant le dialogManager). 

    public bool none() { return true; }


    public bool winFriendshipDoingClown()
    {
        float negociationSkills = 0.3f; //A remplacer par un parametre defini par le joueur
        int nbSentencesBeforeEscape = randomVariables.GetComponent<RandomVariables>().geometricLaw(negociationSkills);
        for (int i = 0; i < nbSentencesBeforeEscape; i++)
        {
            liquidBeer.GetComponent<LiquidScoreColor>().addFriendshipPoint();
        }
        Debug.Log("doing Clown, you have won " + nbSentencesBeforeEscape + " friendship points !");
        enterNewRoom("corridor");
        dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("corridor", 1);
        return false;
    }

    public bool loseFriendshipDoingPrevention()
    {
        float negociationSkills = 0.3f; //A remplacer par un parametre defini par le joueur
        int nbSentencesBeforeEscape = randomVariables.GetComponent<RandomVariables>().geometricLaw(negociationSkills);
        for (int i = 0; i < nbSentencesBeforeEscape; i++)
        {
            liquidBeer.GetComponent<LiquidScoreColor>().removeFriendshipPoint();
        }
        Debug.Log("doing prevention, you have lost " + nbSentencesBeforeEscape + " friendship points !");
        enterNewRoom("corridor");
        return true;
    }

    public bool tryFriendshipToTellSecret()
    {
        int friendshipScore = liquidBeer.GetComponent<LiquidScoreColor>().getFriendshipScore();
        Debug.Log("your friendship score is " + friendshipScore);
        if (friendshipScore >= 5)
        {
            // go to dialog before data occultist
            dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("corridor", 3);
        }
        else
        {
            // go to boss room
            dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("corridor", 2);
        }
        return false;
    }

    public bool enterNewRoom(string newRoom)
    {
        background.GetComponent<backgroundScript>().changeBackground(newRoom);

        if (newRoom == "classroom") { waterDrop.SetActive(false); }
        else if (newRoom == "dataO")
        {
            fumee.SetActive(true);
            fumee.GetComponent<Fumee>().stroboColors();
            dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("dataO");
            return false;
        }
        return true; 
    }
}