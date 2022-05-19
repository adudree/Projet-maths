using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogStepSpace;
using ChoicesSpace;
using System.IO;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject Text;
    public GameObject choice1Button;
    public GameObject choice2Button;
    public GameObject dialogContainer;
    public GameObject charName;
    public GameObject charPicture;
    public int currentStep;

    public Dialogs dialogs = new Dialogs();

    string jsonPath, jsonString;

    public void changeStep(int newStep)
    {
        if (newStep == -1)
        {
            dialogContainer.SetActive(false);
        } else
        {
            currentStep = newStep;
            DialogStep newDialogStep = dialogs.dialogSteps[newStep];
            charName.GetComponent<Text>().text = newDialogStep.characterName;

            charPicture.GetComponent<CharacterPicture>().setCharacterPicture(newDialogStep.characterName);

            Text.GetComponent<DialogSentenceWriter>().changeSentences(newDialogStep.characterSentences);
            //Debug.Log("before set Choice " + newDialogStep.characterName +" and "+ newDialogStep.choice1.buttonText);
            choice1Button.GetComponent<ChoiceButton>().setChoice(newDialogStep.choice1);
            choice2Button.GetComponent<ChoiceButton>().setChoice(newDialogStep.choice2);
        }
        
    }

    public void readJsonDialog()
    {
        jsonPath = Application.streamingAssetsPath + "/dialogues.json";
        jsonString = File.ReadAllText(jsonPath);
        Debug.Log(jsonString);
        dialogs = JsonUtility.FromJson<Dialogs>(jsonString);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        readJsonDialog();

        changeStep(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
