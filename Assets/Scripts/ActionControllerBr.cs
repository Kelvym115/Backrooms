using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionControllerBr : MonoBehaviour
{


    private GameObject itemCollector;
    private GameObject itemCollected;
    private float collectSpeed = 5f;

    private Text textContainer;

    // Start is called before the first frame update
    void Start()
    {
        textContainer = GameObject.Find("TextContainer").GetComponent<Text>();
        //textContainer.text = "What the f... what is this place?";
        StartCoroutine(TextContainerTimer(5));

        itemCollector = GameObject.Find("ItemCollector");
        itemCollected = null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (Input.GetKeyDown("e"))
            {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.name == "teoa_decal"){
                    textContainer.text = "What is this...?";
                    StartCoroutine(TextContainerTimer(3));
                }

                // SEND HIT TO THE MENUBEHAVIOUR IF THE OBJECT IS AN ITEM
                if (hit.collider.gameObject.tag == "Item") {
                    MenuBehaviour menuScript = GameObject.Find("Menu Camera").GetComponent<MenuBehaviour>();
                    if(menuScript != null)
                    {
                        menuScript.GetItem(hit.collider.gameObject.name);
                    }
                }
            }
        } else {
            // nothing yet
        }

        if(itemCollected != null){
            itemCollected.transform.position = Vector3.MoveTowards(itemCollected.transform.position, itemCollector.transform.position, Time.deltaTime * collectSpeed);
        }
    }

    IEnumerator TextContainerTimer(int sec)
    {
        yield return new WaitForSeconds(sec);
        textContainer.text = "";
    }
}
