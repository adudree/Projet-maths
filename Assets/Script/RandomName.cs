using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class RandomName : MonoBehaviour
{
    public List<int> RademacherDraws = new List<int>();

    public GameObject randomVariables;
    

    // set a letter with Rademacher Law : 
    // if rademacher returns 1, char is incremented 
    string setLetter (char c) {
        char newChar = c; 
        int indice = randomVariables.GetComponent<RandomVariables>().rademacherLaw();
        RademacherDraws.Add(indice);
        if (indice == 1) {
            if (c == 'z') newChar = 'a'; 
            else if (c =='Z') newChar = 'A';  
            else newChar = (char)(c + 1);
        }
        if (indice == - 1)
        {
            if (c == 'a') newChar = 'z';
            else if (c == 'A') newChar = 'Z';
            else newChar = (char)(c - 1);
        }
        return newChar.ToString(); 
    }

    // update one char
    string updateChar(string myString, int position) {
        return myString.Remove(position, 1).Insert(position, setLetter(myString[position]));
    }

    //update all chars in a string
    public string updateString(string myString) {
        int compteur = 0;
        foreach(char c in myString) {
            myString = updateChar(myString, compteur);
            compteur++;   
        }
        return myString; 
    }

}
