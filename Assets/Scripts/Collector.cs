using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Trash"){
            Destroy(col.gameObject);
        } else if(col.gameObject.tag == "Bag"){
            Destroy(col.gameObject);
        }
    }
}
