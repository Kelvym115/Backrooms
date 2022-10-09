using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
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
                }
            }
        }
    }
}
