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

    public void actionAndChangeDialogStep()
    {
        actionButtonsTest actionButtonScript = actionButtons.GetComponent<actionButtonsTest>();

        object[] argument = null;
        string methodName;

        if (choice.action.Contains(":"))
        {
            string[] action = choice.action.Split(':');
            string methodParam = action[1];
            methodName = action[0];
            argument = new object[] { methodParam };
        }
        else
        {
            methodName = choice.action; 
        }
        MethodInfo mi = actionButtonScript.GetType().GetMethod(methodName);
        object objectReturn = mi.Invoke(actionButtonScript, argument);
        bool shouldContinue = objectReturn.Equals(true);
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
