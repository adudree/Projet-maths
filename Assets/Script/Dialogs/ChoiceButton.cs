using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogStepSpace;
using ChoicesSpace;
using UnityEngine.UI;
using System.Reflection;


public class ChoiceButton : MonoBehaviour
{

    public Choice choice;
    public Text buttonText;
    public delegate void function();
    public GameObject dialogManager;
    public GameObject actionButtons;

    public void setChoice(Choice newChoice)
    {
        choice = newChoice;
        buttonText.GetComponent<Text>().text = choice.buttonText;
    }

    public void actionAndChangeDialogStep() {
        actionButtonsTest actionButtonScript = actionButtons.GetComponent<actionButtonsTest>();
        MethodInfo mi = actionButtonScript.GetType().GetMethod(choice.action);
        bool shouldContinue;
        object objectReturn = mi.Invoke(actionButtonScript, null);
        shouldContinue = objectReturn.Equals(true);
        Debug.Log("retour value : " + shouldContinue);
        if (shouldContinue)
        {
            dialogManager.GetComponent<DialogManager>().changeStep(choice.nextStep);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(actionAndChangeDialogStep);
    }
}
