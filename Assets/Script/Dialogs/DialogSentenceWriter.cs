using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSentenceWriter : MonoBehaviour
{

    string[] sentences;
    int index = 0;
    bool writing = false;

    public GameObject continueButton;
    public GameObject choice1Button;
    public GameObject choice2Button;
    public GameObject charName;
    public GameObject dialogManager;
    public GameObject specialEvents;

    IEnumerator writeSentence(string sentence)
    {
        continueButton.SetActive(false);
        writing = true;
        gameObject.GetComponent<Text>().text = "";
        foreach (char c in sentence.ToCharArray())
        {
            gameObject.GetComponent<Text>().text += c;
            yield return new WaitForSeconds(0.01f);
        }
        index++;
        writing = false;
        activeContinueButtonIfSentencesComing();
        callEventAfterTextIsFinish();
        giveChoicesIfTextIsFinish();
    }

    public void callEventAfterTextIsFinish()
    {
        if (index == sentences.Length && writing == false)
        {
            int currentDialogStep = dialogManager.GetComponent<DialogManager>().currentStep;
            specialEvents.GetComponent<SpecialEvents>().goEvent(currentDialogStep);
        }
    }

    public void giveChoicesIfTextIsFinish()
    {
        if (index == sentences.Length && writing == false)
        {
            continueButton.SetActive(false);
            choice1Button.SetActive(true);

            string nameOfCharacter = charName.GetComponent<Text>().text;
            if (nameOfCharacter != "Me")
            {
                choice2Button.SetActive(true);
            }
        }
    }

    public void activeContinueButtonIfSentencesComing()
    {
        if (sentences.Length != 1 && index < sentences.Length)
        {
            continueButton.SetActive(true);
        }
    }


    public void continueText()
    {
        if (index < sentences.Length && writing == false)
        {
            StartCoroutine(writeSentence(sentences[index]));
        }
        //giveChoicesIfTextIsFinish();
    }

    public void changeSentences(string[] newSentences)
    {
        if (sentences == null || index == sentences.Length)
        {
            sentences = newSentences;
            index = 0;
            choice1Button.SetActive(false);
            choice2Button.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       /* sentences = new string[3];
        sentences[0] = "Je suis une patate.";
        sentences[1] = "Mais je fais ce que je peux.";
        sentences[2] = "Même si c'est difficile.";

        sentences2 = new string[2];
        sentences2[0] = "Olala";
        sentences2[1] = "C'est la panique";*/

        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 0 && writing == false && sentences != null)
        {
            StartCoroutine(writeSentence(sentences[index]));
           /* if(sentences.Length != 1)
            {
                continueButton.SetActive(true);
            }*/
            //giveChoicesIfTextIsFinish();
        }
/*
        if (Input.GetKeyDown("space"))
        {
            //print("space key was pressed");
            changeSentences(sentences2);
               
        }*/
    }

}
