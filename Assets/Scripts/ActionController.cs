using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public Animator door1Anim;
    public Animator door2Anim;

    public bool door1Open;
    public bool door2Open;

    // Start is called before the first frame update
    void Start()
    {
        door1Open = false;
        door1Anim = GameObject.Find("Door1").GetComponent<Animator>();
        door2Open = true;
        door2Anim = GameObject.Find("Door2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        door1Anim.SetBool("isOpen", door1Open);
        door2Anim.SetBool("isOpen", door2Open);

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
                }
            }
        }
    }
}
