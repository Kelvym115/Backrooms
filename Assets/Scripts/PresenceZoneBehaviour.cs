using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenceZoneBehaviour : MonoBehaviour
{
    [Header("General Settings")]
    
    public GameObject presenceZone;
    public int zoneSize = 5;

    [Space(10)]

    public GameObject[] zones;

    // Start is called before the first frame update
    void Start()
    {
        string orientation;
        orientation = "Z";
        for (int i = 0; i < 8; i++)
        {
            if(orientation == "Z"){
                GameObject zoneClone = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(0,0,transform.position.z + zoneSize), transform.rotation) as GameObject;
                zoneClone.transform.parent = presenceZone.transform;
                zoneClone.tag = "N";
                orientation = "N";
            } else if (orientation == "N")
            {
                GameObject zoneClone = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(transform.position.x + zoneSize,0,transform.position.z + zoneSize), transform.rotation) as GameObject;
                zoneClone.transform.parent = presenceZone.transform;
                zoneClone.tag = "NE";
                orientation = "NE";
            } else if (orientation == "NE")
            {
                GameObject zoneClone = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(transform.position.x + zoneSize,0,0), transform.rotation) as GameObject;
                zoneClone.transform.parent = presenceZone.transform;
                zoneClone.tag = "E";
                orientation = "E";
            } else if (orientation == "E")
            {
                GameObject zoneClone = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(transform.position.x + zoneSize,0,transform.position.z - zoneSize), transform.rotation) as GameObject;
                zoneClone.transform.parent = presenceZone.transform;
                zoneClone.tag = "SE";
                orientation = "SE";
            } else if (orientation == "SE")
            {
                GameObject zoneClone = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(0,0,transform.position.z - zoneSize), transform.rotation) as GameObject;
                zoneClone.transform.parent = presenceZone.transform;
                zoneClone.tag = "S";
                orientation = "S";
            } else if (orientation == "S")
            {
                GameObject zoneClone = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(transform.position.x - zoneSize,0,transform.position.z - zoneSize), transform.rotation) as GameObject;
                zoneClone.transform.parent = presenceZone.transform;
                zoneClone.tag = "SW";
                orientation = "SW";
            } else if (orientation == "SW")
            {
                GameObject zoneClone = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(transform.position.x - zoneSize,0,0), transform.rotation) as GameObject;
                zoneClone.transform.parent = presenceZone.transform;
                zoneClone.tag = "W";
                orientation = "W";
            } else if (orientation == "W")
            {
                GameObject zoneClone = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(transform.position.x - zoneSize,0,transform.position.z + zoneSize), transform.rotation) as GameObject;
                zoneClone.transform.parent = presenceZone.transform;
                zoneClone.tag = "NW";
                orientation = "NW";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
