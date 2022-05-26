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
    public GameObject actionButton;

    string playerName = "";

    public void loadPlayerName()
    {
        playerName = PlayerPrefs.GetString("playerName");
    }
    IEnumerator writeSentence(string sentence)
    {
        // replace name in sentence
        string playerName = PlayerPrefs.GetString("playerName");
        if (PlayerPrefs.HasKey("playerName")) sentence = nameInSentence(playerName, sentence);

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


    string nameInSentence(string newName, string sentence)
    {
        if (sentence.Contains("%name%"))
        {
            return sentence.Replace("%name%", newName);
        }
        return sentence;
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
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 0 && writing == false && sentences != null)
        {
            StartCoroutine(writeSentence(sentences[index]));
        }
    }

}
