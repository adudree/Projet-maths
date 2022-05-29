using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionButtonsTest : MonoBehaviour
{
    public GameObject waterDrop;
    public GameObject background;
    public GameObject randomVariables;
    public GameObject randomName;
    public GameObject liquidBeer;
    public GameObject dialogManager;
    public GameObject fumee;
    public GameObject playerName;
    public GameObject GameStatsArray;
    public string finalName;
    public int nbDessert;

    public bool victory = false;

    [SerializeField] GameObject table;
    [SerializeField] GameObject dessert;

    //Les fonctions doivent retourner true si apres l'action le dialogue continue normalement, 
    //et false pour gerer elle meme l'appel au dialogStep suivant (en bloquant le dialogManager). 

    public bool none() { return true; }

    public bool askName()
    {
        playerName.SetActive(true);
        return false;
    }


    public void skipButton()
    {
        background.GetComponent<backgroundScript>().changeBackground("corridor");
        dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("corridor");
        table.SetActive(false);
    }

    // called when input field is submitted 
    public void setPlayerName()
    {
        finalName = randomName.GetComponent<RandomName>().updateString(playerName.GetComponent<InputField>().text);
        PlayerPrefs.SetString("playerName", finalName);

        playerName.SetActive(false);
        dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("hostel", 8);
    }

    // called when buttons are clicked 
    public bool yesName()
    {
        dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("hostel", 10);
        return true;
    }

    public bool noName()
    {
        finalName = randomName.GetComponent<RandomName>().updateString(finalName);
        PlayerPrefs.SetString("playerName", finalName);

        dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("hostel", 9);
        return true;
    }

    public bool winFriendshipDoingClown()
    {
        float negociationSkills = PlayerPrefs.GetFloat("negociation", 0.3f);
        int nbSentencesBeforeEscape = randomVariables.GetComponent<RandomVariables>().geometricLaw(negociationSkills);
        PlayerPrefs.SetInt("nbSentences", nbSentencesBeforeEscape);
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
        float negociationSkills = PlayerPrefs.GetFloat("negociation", 0.3f);
        int nbSentencesBeforeEscape = randomVariables.GetComponent<RandomVariables>().geometricLaw(negociationSkills);
        PlayerPrefs.SetInt("nbSentences", nbSentencesBeforeEscape);
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
        waterDrop.SetActive(isWaterDropActive(newRoom));

        if (newRoom == "dataO")
        {
            fumee.SetActive(true);
            fumee.GetComponent<Fumee>().stroboColors();
            dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("dataO");
            return false;
        }
        else if (newRoom == "bossRoom")
        {
            Debug.Log(victory);
            if (victory)
            {
                dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("bossRoom", 1);
            }
            else
            {
                dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("bossRoom", 0);
            }
            return false;
        }
        else return true;
    }
    /*
        public bool calculateNbDessert()
        {
            float hungry = PlayerPrefs.GetFloat("cooking");
            nbDessert = randomVariables.GetComponent<RandomVariables>().PoissonLaw(hungry);
            PlayerPrefs.SetInt("nbDessert", nbDessert);
            return true;
        }*/

    public bool calculateNbDessert()
    {
        //maintenant on calcule au debut (test)
        return true;
    }

    public bool allowVictory()
    {
        hideStats();
        victory = true;
        fumee.SetActive(false);
        background.GetComponent<backgroundScript>().changeBackground("corridor");
        dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("corridor", 4);
        return false;
    }

    public bool showStats()
    {
        GameStatsArray.GetComponent<GameStats>().showStats();
        return true;
    }

    public bool hideStats()
    {
        GameStatsArray.SetActive(false);
        return true;
    }

    bool isWaterDropActive(string room)
    {
        return room == "entrance";
    }

    public bool backToCorridor()
    {
        background.GetComponent<backgroundScript>().changeBackground("corridor");
        dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("corridor", 5);
        return false;
    }

    public bool backToHostel()
    {
        background.GetComponent<backgroundScript>().changeBackground("hostel");
        dialogManager.GetComponent<DialogManager>().setNewCurrentDialog("hostel", 13);
        dessert.SetActive(true);
        table.SetActive(true);
        return false;
    }
}
