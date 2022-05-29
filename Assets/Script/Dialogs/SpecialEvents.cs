using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEvents : MonoBehaviour
{
    public GameObject waterDrop;

    void waterDropAppears()
    {
        waterDrop.GetComponent<WaterDrop>().makeDropAppear();
    }

    public void goEvent(int dialogStep, string currentDialog)
    {
        
        if (dialogStep == 12 && currentDialog == "entrance")
        {
            waterDropAppears();
        }
    }

}
