using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    private Animator door1Anim;
    private Animator door2Anim;
    private Animator door3Anim;
    private Animator door4Anim;

    private bool door1Open;
    private bool door2Open;
    private bool door3Open;
    private bool door4Open;

    private GameObject itemCollector;
    private GameObject itemCollected;
    private float collectSpeed = 5f;
    private bool bagCollected;

    private BoxCollider outsideFloor;

    //private GameObject actionTextObj;
    //private Text actionText;

    // Light Controllers

    private GameObject cone1;
    private GameObject light1;

    private GameObject cone2;
    private GameObject light2;

    private GameObject cone3;
    private GameObject light3;

    private GameObject cone4;
    private GameObject light4;

    private GameObject cone5;
    private GameObject light5;

    private GameObject cone6;
    private GameObject light6;

    // Start is called before the first frame update
    void Start()
    {
        //actionTextObj =  GameObject.Find("ActionText");
        //actionTextObj.GetComponent<UnityEngine.UI.Text>().text = "Aperte E";
        //actionTextObj.SetActive(false);

        cone1 = GameObject.Find("cone1");
        light1 = GameObject.Find("light1");
        light1.SetActive(true);

        cone2 = GameObject.Find("cone2");
        light2 = GameObject.Find("light2");
        light2.SetActive(true);

        cone3 = GameObject.Find("cone3");
        light3 = GameObject.Find("light3");
        light3.SetActive(false);

        cone4 = GameObject.Find("cone4");
        light4 = GameObject.Find("light4");
        light4.SetActive(true);

        cone5 = GameObject.Find("cone5");
        light5 = GameObject.Find("light5");
        light5.SetActive(false);

        cone6 = GameObject.Find("cone6");
        light6 = GameObject.Find("light6");
        light6.SetActive(false);

        outsideFloor = GameObject.Find("OutsideFloor").GetComponent<BoxCollider>();

        itemCollector = GameObject.Find("ItemCollector");
        itemCollected = null;

        bagCollected = false;

        door1Open = false;
        door1Anim = GameObject.Find("Door1").GetComponent<Animator>();
        door2Open = true;
        door2Anim = GameObject.Find("Door2").GetComponent<Animator>();
        door3Open = true;
        door3Anim = GameObject.Find("Door3").GetComponent<Animator>();    
        door4Open = true;
        door4Anim = GameObject.Find("Door4").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        door1Anim.SetBool("isOpen", door1Open);
        door2Anim.SetBool("isOpen", door2Open);
        door3Anim.SetBool("isOpen", door3Open);
        door4Anim.SetBool("isOpen", door4Open);

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            // if(hit.collider.gameObject.tag == "Bag" || hit.collider.gameObject.tag == "LightPlug" || hit.collider.gameObject.tag == "Door"){
            //     actionTextObj.SetActive(true);
            //     actionTextObj.GetComponent<UnityEngine.UI.Text>().text = "Aperte E";
            // } else {
            //     actionTextObj.SetActive(false);
            // }

            if (Input.GetKeyDown("e"))
            {
                if(hit.collider.gameObject.name == "Door1_Wood"){
                    print(hit.collider.gameObject.name);
                    if(door1Open){
                        door1Open = false;
                    } else {
                        door1Open = true;
                    }
                } else if(hit.collider.gameObject.name == "Door2_Wood"){
                    print(hit.collider.gameObject.name);
                    if(door2Open){
                        door2Open = false;
                    } else {
                        door2Open = true;
                    }
                } else if(hit.collider.gameObject.name == "Door3_Wood"){
                    print(hit.collider.gameObject.name);
                    if(door3Open){
                        door3Open = false;
                    } else {
                        door3Open = true;
                    }
                } else if(hit.collider.gameObject.name == "Door4_Wood"){
                    print(hit.collider.gameObject.name);
                    if(door4Open){
                        door4Open = false;
                    } else {
                        door4Open = true;
                    }
                } else if(hit.collider.gameObject.tag == "Bag"){
                    itemCollected = hit.collider.gameObject;
                    bagCollected = true;
                    outsideFloor.center = new Vector3(-17f, 0f, -5.4f);
                    outsideFloor.size= new Vector3(5.98f, 0f, 3f);
                } else if(hit.collider.gameObject.tag == "Trash" && bagCollected){
                    itemCollected = hit.collider.gameObject;
                } else if(hit.collider.gameObject.tag == "LightPlug"){
                    if(hit.collider.gameObject.name == "LightPlug (3)"){
                        if(light4.activeInHierarchy){
                            light4.SetActive(false);
                        } else {
                            light4.SetActive(true);
                        }
                    } else if(hit.collider.gameObject.name == "LightPlug (2)"){
                        if(light1.activeInHierarchy){
                            light1.SetActive(false);
                            light2.SetActive(false);
                        } else {
                            light1.SetActive(true);
                            light2.SetActive(true);
                        }
                    } else if(hit.collider.gameObject.name == "LightPlug (4)"){
                        if(light3.activeInHierarchy){
                            light3.SetActive(false);
                        } else {
                            light3.SetActive(true);
                        }
                    } else if(hit.collider.gameObject.name == "LightPlug (5)"){
                        if(light5.activeInHierarchy){
                            light5.SetActive(false);
                        } else {
                            light5.SetActive(true);
                        }
                    } else if(hit.collider.gameObject.name == "LightPlug (1)"){
                        if(light6.activeInHierarchy){
                            light6.SetActive(false);
                        } else {
                            light6.SetActive(true);
                        }
                    }
                } 
            }
        } else {
            //actionTextObj.SetActive(false);
        }

        if(itemCollected != null){
            itemCollected.transform.position = Vector3.MoveTowards(itemCollected.transform.position, itemCollector.transform.position, Time.deltaTime * collectSpeed);
        }
    }
}
