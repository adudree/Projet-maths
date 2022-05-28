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
    public DialogStep[] currentDialog = new DialogStep[0];
    public string actualDialog;

    string jsonPath, jsonString;
    string playerName;

    public void changeStep(int newStep)
    {
        if (newStep == -1)
        {
            // dialogContainer.SetActive(false);
            switchDialogType();
        }
        else
        {
            currentStep = newStep;
            setNewStep(currentDialog[newStep]);
        }
    }

    public void loadPlayerName()
    {

    }

    void switchDialogType()
    {
        switch (actualDialog)
        {
            case "hostel":
                setNewCurrentDialog("entrance");
                break;
            case "entrance":
                setNewCurrentDialog("classroom");
                break;
            case "classroom":
                setNewCurrentDialog("corridor");
                break;
            case "corridor":
                setNewCurrentDialog("bossRoom");
                break;
            case "dataO":
                setNewCurrentDialog("bossRoom");
                break;
            default:
                break;
        }
    }

    public void setNewCurrentDialog(string dialog, int step = 0)
    {
        switch (dialog)
        {
            case "hostel":
                currentDialog = dialogs.dialogHostel;
                actualDialog = "hostel";
                break; 
            case "entrance":
                currentDialog = dialogs.dialogEntrance;
                actualDialog = "entrance";
                break;
            case "classroom":
                currentDialog = dialogs.dialogClassroom;
                actualDialog = "classroom";
                break;
            case "corridor":
                currentDialog = dialogs.dialogCorridor;
                actualDialog = "corridor";
                break;
            case "bossRoom":
                currentDialog = dialogs.dialogBossRoom;
                actualDialog = "bossRoom";
                break;
            case "dataO":
                currentDialog = dialogs.dialogDataO;
                actualDialog = "dataO";
                break;
            default:
                break;
        }
        setNewStep(currentDialog[step]);
    }

    void setNewStep(DialogStep newDialogStep)
    {
        charName.GetComponent<Text>().text = newDialogStep.characterName;

        // switch "me" into playerName
        playerName = PlayerPrefs.GetString("playerName", "fauxprenom");
        if (PlayerPrefs.HasKey("playerName") && charName.GetComponent<Text>().text == "Me") charName.GetComponent<Text>().text = playerName;
        Debug.Log(newDialogStep.characterName); 

        charPicture.GetComponent<CharacterPicture>().setCharacterPicture(newDialogStep.characterName);
        Text.GetComponent<DialogSentenceWriter>().changeSentences(newDialogStep.characterSentences);
        choice1Button.GetComponent<ChoiceButton>().setChoice(newDialogStep.choice1);
        choice2Button.GetComponent<ChoiceButton>().setChoice(newDialogStep.choice2);
    }

    public void readJsonDialog()
    {
        jsonPath = Application.streamingAssetsPath + "/dialogues.json";
        jsonString = File.ReadAllText(jsonPath);
        dialogs = JsonUtility.FromJson<Dialogs>(jsonString);

        currentDialog = dialogs.dialogHostel;
        actualDialog = "hostel";
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("playerName");

        readJsonDialog();
        changeStep(0);
    }

}
