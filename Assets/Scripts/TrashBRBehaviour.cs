using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBRBehaviour : MonoBehaviour
{
    
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(player){
            float dist = Vector3.Distance(player.transform.position, transform.position);

            if (dist >= 75){
                Destroy(gameObject);
            }
        }
    }
}
