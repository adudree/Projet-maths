using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BefriendBottle : MonoBehaviour
{
    public GameObject liquidBeer;
    public GameObject maskBeer;

    void OnMouseDown()
    {
        liquidBeer.GetComponent<LiquidScoreColor>().addFriendshipPoint();
        maskBeer.GetComponent<MaskSoberScore>().removeSobrietyPoint();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
