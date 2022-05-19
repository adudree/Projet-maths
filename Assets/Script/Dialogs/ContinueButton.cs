using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Text.GetComponent<DialogSentenceWriter>().continueText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
