using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public GameObject liquidBeer;
    public GameObject maskBeer;
    public GameObject dialogManager;
    public GameObject randomVariables;

    Vector3 dropPosition;
    float outOfWindowUpY = 5.65f;
    float outOfWindowDownY = -5.62f;
    float onCeilingY = 4.69f;
    float speed = 1.001f;
    float step = 0.1f;
    bool falls = false;
    bool appears = false;

    //public Camera camera;

    float randomXposition()
    {
        float xMin = -9f;
        float xMax = 8.5f;
        float xRandom = randomVariables.GetComponent<RandomVariables>().uniformLaw(xMin, xMax);
        return xRandom;
    }

    // Start is called before the first frame update
    void Start()
    {
        dropPosition = gameObject.GetComponent<Transform>().position;
        dropPosition.y = outOfWindowUpY;
        dropPosition.x = randomXposition();
        gameObject.GetComponent<Transform>().position = dropPosition;
    }


    IEnumerator waitAndFall()
    {
        float parameter = 0.559f;
        float timeBeforeFall = randomVariables.GetComponent<RandomVariables>().exponentialLaw(parameter);
        Debug.Log("time to wait before the water drop falls : " + timeBeforeFall + " seconds");
        yield return new WaitForSeconds(timeBeforeFall);
        falls = true;
       
    }

    public void makeDropAppear()
    {
        appears = true;
    }

    void dropAppears()
    {
        dropPosition = gameObject.GetComponent<Transform>().position;
        if (dropPosition.y > onCeilingY)
        {
            dropPosition.y -= 0.01f;
            gameObject.GetComponent<Transform>().position = dropPosition;
        } else
        {
            appears = false;
            StartCoroutine(waitAndFall());
        }
    }

    void dropFalls()
    {
        dropPosition = gameObject.GetComponent<Transform>().position;
        if (dropPosition.y > outOfWindowDownY)
        {
            step = step * speed;
            dropPosition.y -= step;
            gameObject.GetComponent<Transform>().position = dropPosition;
        } else
        {
            gameObject.SetActive(false); 
            falls = false;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("click Water");
        liquidBeer.GetComponent<LiquidScoreColor>().removeFriendshipPoint();
        maskBeer.GetComponent<MaskSoberScore>().addSobrietyPoint();
        gameObject.SetActive(false);
        dialogManager.GetComponent<DialogManager>().changeStep(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (appears)
        {
            dropAppears();
        }
        if (falls)
        {
            dropFalls();
        }
        
       /*   //Méthode plus complexe pour détecter si un sprite est cliqué mais ça marche... au cas où :
            Vector2 mouseWorldPosition = camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);

            if (hitInfo != null)
            {
                Debug.Log(hitInfo.transform.gameObject.name);
            }
        }*/
    }
}
