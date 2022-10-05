using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoneDet : MonoBehaviour
{
    public GameObject presenceZone;
    public float zoneSize = 5f;
    public GameObject[] zones;

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
        if (col.gameObject.tag == "Z")
        {
            //Do nothing yet
        } else if (col.gameObject.tag == "N")
        {
            Destroy (GameObject.FindWithTag("S"));
            Destroy (GameObject.FindWithTag("SW"));
            Destroy (GameObject.FindWithTag("SE"));

            GameObject W = GameObject.FindWithTag("W");
            W.tag = "SW";
            GameObject NW = GameObject.FindWithTag("NW");
            NW.tag = "W";
            GameObject Z = GameObject.FindWithTag("Z");
            Z.tag = "S";
            GameObject E = GameObject.FindWithTag("E");
            E.tag = "SE";
            GameObject NE = GameObject.FindWithTag("NE");
            NE.tag = "E";

            col.gameObject.tag = "Z";

            GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x,0,col.gameObject.transform.position.z + zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone1.transform.parent = presenceZone.transform;
            zoneClone1.tag = "N";

            GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x + zoneSize,0,col.gameObject.transform.position.z + zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone2.transform.parent = presenceZone.transform;
            zoneClone2.tag = "NE";

            GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x - zoneSize,0,col.gameObject.transform.position.z + zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone3.transform.parent = presenceZone.transform;
            zoneClone3.tag = "NW";
        } else if (col.gameObject.tag == "S")
        {
            Destroy (GameObject.FindWithTag("N"));
            Destroy (GameObject.FindWithTag("NW"));
            Destroy (GameObject.FindWithTag("NE"));

            GameObject W = GameObject.FindWithTag("W");
            W.tag = "NW";
            GameObject SW = GameObject.FindWithTag("SW");
            SW.tag = "W";
            GameObject Z = GameObject.FindWithTag("Z");
            Z.tag = "N";
            GameObject E = GameObject.FindWithTag("E");
            E.tag = "NE";
            GameObject SE = GameObject.FindWithTag("SE");
            SE.tag = "E";

            col.gameObject.tag = "Z";

            GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x,0,col.gameObject.transform.position.z - zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone1.transform.parent = presenceZone.transform;
            zoneClone1.tag = "S";

            GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x + zoneSize,0,col.gameObject.transform.position.z - zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone2.transform.parent = presenceZone.transform;
            zoneClone2.tag = "SE";

            GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x - zoneSize,0,col.gameObject.transform.position.z - zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone3.transform.parent = presenceZone.transform;
            zoneClone3.tag = "SW";
        } else if (col.gameObject.tag == "E")
        {
            Destroy (GameObject.FindWithTag("NW"));
            Destroy (GameObject.FindWithTag("W"));
            Destroy (GameObject.FindWithTag("SW"));

            GameObject N = GameObject.FindWithTag("N");
            N.tag = "NW";
            GameObject NE = GameObject.FindWithTag("NE");
            NE.tag = "N";
            GameObject Z = GameObject.FindWithTag("Z");
            Z.tag = "W";
            GameObject S = GameObject.FindWithTag("S");
            S.tag = "SW";
            GameObject SE = GameObject.FindWithTag("SE");
            SE.tag = "S";

            col.gameObject.tag = "Z";

            GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x + zoneSize,0,col.gameObject.transform.position.z + zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone1.transform.parent = presenceZone.transform;
            zoneClone1.tag = "NE";

            GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x + zoneSize,0,col.gameObject.transform.position.z), col.gameObject.transform.rotation) as GameObject;
            zoneClone2.transform.parent = presenceZone.transform;
            zoneClone2.tag = "E";

            GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x + zoneSize,0,col.gameObject.transform.position.z - zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone3.transform.parent = presenceZone.transform;
            zoneClone3.tag = "SE";
        } else if (col.gameObject.tag == "W")
        {
            Destroy (GameObject.FindWithTag("NE"));
            Destroy (GameObject.FindWithTag("E"));
            Destroy (GameObject.FindWithTag("SE"));

            GameObject N = GameObject.FindWithTag("N");
            N.tag = "NE";
            GameObject NW = GameObject.FindWithTag("NW");
            NW.tag = "N";
            GameObject Z = GameObject.FindWithTag("Z");
            Z.tag = "E";
            GameObject S = GameObject.FindWithTag("S");
            S.tag = "SE";
            GameObject SW = GameObject.FindWithTag("SW");
            SW.tag = "S";

            col.gameObject.tag = "Z";

            GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x - zoneSize,0,col.gameObject.transform.position.z + zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone1.transform.parent = presenceZone.transform;
            zoneClone1.tag = "NW";

            GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x - zoneSize,0,col.gameObject.transform.position.z), col.gameObject.transform.rotation) as GameObject;
            zoneClone2.transform.parent = presenceZone.transform;
            zoneClone2.tag = "W";

            GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Length)], new Vector3(col.gameObject.transform.position.x - zoneSize,0,col.gameObject.transform.position.z - zoneSize), col.gameObject.transform.rotation) as GameObject;
            zoneClone3.transform.parent = presenceZone.transform;
            zoneClone3.tag = "SW";
        }
    }
}
