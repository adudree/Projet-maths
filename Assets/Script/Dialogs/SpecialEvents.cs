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

    public void goEvent(int dialogStep)
    {
        if (dialogStep == 0)
        {
            waterDropAppears();
        }
    }

}
