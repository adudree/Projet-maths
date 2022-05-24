using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class RandomName : MonoBehaviour
{

    public GameObject randomVariables;
    public InputField playerName; 
    public string finalName; 

    // set a letter with Rademacher Law : 
    // if rademacher returns 1, char is incremented 
    string setLetter (char c) {
        char newChar = c; 
        int indice = randomVariables.GetComponent<RandomVariables>().rademacherLaw();
        if (indice == 1) {
            if (c == 'z') newChar = 'a'; 
            else if (c =='Z') newChar = 'A';  
            else newChar = (char)(c + 1);
        }
        return newChar.ToString(); 
    }

    // update one char
    string updateChar(string myString, int position) {
        return myString.Remove(position, 1).Insert(position, setLetter(myString[position]));
    }

    //update all chars in a string
    void updateString(string myString) {
        int compteur = 0;
        foreach(char c in myString) {
            myString = updateChar(myString, compteur);
            compteur++;   
        }
        finalName = myString; 
    }
    
    // called when input field is submitted 
    public void setPlayerName() {
        finalName = playerName.text; 
        Debug.Log("oh, tu t'appelles " + finalName + " ?");
    }


    // called when buttons are clicked 
    public void oui () {
        Debug.Log("tu t'appelles donc " + finalName + " pour la vie.");
    }
    public void non () {
         updateString(finalName);
        Debug.Log("ton prénom, c'est " + finalName + " alors ?");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    new void Update()
    {
        // Restart with space (c pratique) (mais moche)
        if (Input.GetKeyDown("space")) {
            Start();
        }        
    }
}
