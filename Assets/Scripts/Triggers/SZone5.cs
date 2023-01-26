using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZone5 : MonoBehaviour
{
    private GameObject bacteria;
    // Start is called before the first frame update
    void Start()
    {
        bacteria = GameObject.Find("BacteriaTrigger");
        bacteria.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player_Test"){
            bacteria.SetActive(true);
            Destroy(gameObject);
        }
    }
}
