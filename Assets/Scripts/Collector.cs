using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private GameObject garbageBag;

    // Start is called before the first frame update
    void Start()
    {
        garbageBag = GameObject.Find("garbagebag--");
        garbageBag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "Trash"){
            Destroy(col.gameObject);
        } else if(col.gameObject.tag == "Bag"){
            garbageBag.SetActive(true);
            Destroy(col.gameObject);
        }
    }
}
