using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogStepSpace;

namespace ChoicesSpace
{
    [System.Serializable]
    public class Choice
    {
        public string buttonText;
        //public DialogStep nextStep;
        public int nextStep;
        /*public delegate void toDoWhenChosen();
        public toDoWhenChosen action;*/
        public string action;
    }
}