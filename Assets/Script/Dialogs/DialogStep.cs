using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChoicesSpace;

namespace DialogStepSpace
{
    [System.Serializable]
    public class DialogStep
    {
        public string characterName;
        public string[] characterSentences;
        public Choice choice1;
        public Choice choice2;
    }


    [System.Serializable]
    public class Dialogs
    {
        public DialogStep[] dialogSteps;
        public DialogStep[] dialogHostel;
        public DialogStep[] dialogEntrance;
        public DialogStep[] dialogClassroom;
        public DialogStep[] dialogCorridor;
        public DialogStep[] dialogDataO;
        public DialogStep[] dialogBossRoom;
        public DialogStep[] test;
    }
}

