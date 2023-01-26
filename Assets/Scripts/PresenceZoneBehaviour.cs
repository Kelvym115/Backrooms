using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenceZoneBehaviour : MonoBehaviour
{
    [Header("General Settings")]
    
    public GameObject presenceZone;
    public float zoneSize = 5f;

    [Space(10)]

    public GameObject[] zones;

    // Start is called before the first frame update
    void Start()
    {
        GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(0,0,zoneSize), transform.rotation) as GameObject;
        zoneClone1.transform.parent = presenceZone.transform;
        zoneClone1.tag = "N";
        GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(zoneSize,0,zoneSize), transform.rotation) as GameObject;
        zoneClone2.transform.parent = presenceZone.transform;
        zoneClone2.tag = "NE";
        GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(zoneSize,0,0), transform.rotation) as GameObject;
        zoneClone3.transform.parent = presenceZone.transform;
        zoneClone3.tag = "E";
        GameObject zoneClone4 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(zoneSize,0,-zoneSize), transform.rotation) as GameObject;
        zoneClone4.transform.parent = presenceZone.transform;
        zoneClone4.tag = "SE";
        GameObject zoneClone5 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(0,0,-zoneSize), transform.rotation) as GameObject;
        zoneClone5.transform.parent = presenceZone.transform;
        zoneClone5.tag = "S";
        GameObject zoneClone6 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(-zoneSize,0,-zoneSize), transform.rotation) as GameObject;
        zoneClone6.transform.parent = presenceZone.transform;
        zoneClone6.tag = "SW";
        GameObject zoneClone7 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(-zoneSize,0,0), transform.rotation) as GameObject;
        zoneClone7.transform.parent = presenceZone.transform;
        zoneClone7.tag = "W";
        GameObject zoneClone8 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(-zoneSize,0,zoneSize), transform.rotation) as GameObject;
        zoneClone8.transform.parent = presenceZone.transform;
        zoneClone8.tag = "NW";
    }
}
