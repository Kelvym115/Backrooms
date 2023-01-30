using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerZoneDet : MonoBehaviour
{
    public GameObject presenceZone;
    public float zoneSize = 5f;
    public List<GameObject> zones;
    public List<GameObject> sZones;
    public int SpecialZoneChance = 3;

    private Transform player;

    public LayerMask collector;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, 3f, ~collector))
        {
            //Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "Z")
            {
                // do nothing
            } else if (hit.collider.tag == "N")
            {
                Destroy (GameObject.FindWithTag("S"));
                Destroy (GameObject.FindWithTag("SW"));
                Destroy (GameObject.FindWithTag("SE"));

                if(hit.collider.name.Contains("s_") && sZones.Count != 0){
                    // DELETAR DO ARRAY DE ESPECIAIS SE PISAR
                    // VERIFICAR O COUNT PODE ESTAR COM PROBLEMA NA CONTAGEM
                    for (int i = 0; i < sZones.Count; i++) {
                        if(hit.collider.name.Contains(sZones[i].gameObject.name)){
                            sZones.Remove(sZones[i]);
                        }
                    }
                }

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

                hit.collider.tag = "Z";

                bool range1 = false;
                if(player.position.x < -15 && player.position.x > -200 && player.position.z < -200 && player.position.z > -400){
                    range1 = true;
                }

                // SPECIAL ZONES CONTROLLER
                int specialRead = Random.Range(0, 100);
                List<GameObject> newZone;

                int zoneIndex;

                if(specialRead <= SpecialZoneChance && range1 == false && sZones.Count != 0){
                    newZone = sZones;
                    zoneIndex = Random.Range(0, sZones.Count );
                } else {
                    newZone = zones;
                    zoneIndex = Random.Range(0, newZone.Count );
                }

                // END OF SPECIAL ZONES CONTROLLER
                // ONLY AFFECT N ZONES IN THIS CASE

                GameObject zoneClone1 = Instantiate(range1 ? zones[14] : newZone[zoneIndex], new Vector3(hit.collider.gameObject.transform.position.x,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone1.transform.parent = presenceZone.transform;
                zoneClone1.tag = "N";

                GameObject zoneClone2 = Instantiate(range1 ? zones[14] : zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone2.transform.parent = presenceZone.transform;
                zoneClone2.tag = "NE";

                GameObject zoneClone3 = Instantiate(range1 ? zones[14] : zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone3.transform.parent = presenceZone.transform;
                zoneClone3.tag = "NW";
            } else if (hit.collider.tag == "S")
            {
                Destroy (GameObject.FindWithTag("N"));
                Destroy (GameObject.FindWithTag("NW"));
                Destroy (GameObject.FindWithTag("NE"));

                if(hit.collider.name.Contains("s_") && sZones.Count != 0){
                    // DELETAR DO ARRAY DE ESPECIAIS SE PISAR
                    // VERIFICAR O COUNT PODE ESTAR COM PROBLEMA NA CONTAGEM
                    for (int i = 0; i < sZones.Count; i++) {
                        if(hit.collider.name.Contains(sZones[i].gameObject.name)){
                            sZones.Remove(sZones[i]);
                        }
                    }
                }

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

                hit.collider.tag = "Z";

                bool range1 = false;
                if(player.position.x < -15 && player.position.x > -200 && player.position.z < -200 && player.position.z > -400){
                    range1 = true;
                }

                // SPECIAL ZONES CONTROLLER
                int specialRead = Random.Range(0, 100);
                List<GameObject> newZone;

                int zoneIndex;

                if(specialRead <= SpecialZoneChance && range1 == false && sZones.Count != 0){
                    newZone = sZones;
                    zoneIndex = Random.Range(0, sZones.Count );
                } else {
                    newZone = zones;
                    zoneIndex = Random.Range(0, newZone.Count );
                }

                // END OF SPECIAL ZONES CONTROLLER
                // ONLY AFFECT N ZONES IN THIS CASE

                GameObject zoneClone1 = Instantiate(range1 ? zones[14] : newZone[zoneIndex], new Vector3(hit.collider.gameObject.transform.position.x,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone1.transform.parent = presenceZone.transform;
                zoneClone1.tag = "S";

                GameObject zoneClone2 = Instantiate(range1 ? zones[14] : zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone2.transform.parent = presenceZone.transform;
                zoneClone2.tag = "SE";

                GameObject zoneClone3 = Instantiate(range1 ? zones[14] : zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone3.transform.parent = presenceZone.transform;
                zoneClone3.tag = "SW";
            } else if (hit.collider.tag == "E")
            {
                Destroy (GameObject.FindWithTag("NW"));
                Destroy (GameObject.FindWithTag("W"));
                Destroy (GameObject.FindWithTag("SW"));

                if(hit.collider.name.Contains("s_") && sZones.Count != 0){
                    // DELETAR DO ARRAY DE ESPECIAIS SE PISAR
                    // VERIFICAR O COUNT PODE ESTAR COM PROBLEMA NA CONTAGEM
                    for (int i = 0; i < sZones.Count; i++) {
                        if(hit.collider.name.Contains(sZones[i].gameObject.name)){
                            sZones.Remove(sZones[i]);
                        }
                    }
                }

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

                hit.collider.tag = "Z";

                bool range1 = false;
                if(player.position.x < -15 && player.position.x > -200 && player.position.z < -200 && player.position.z > -400){
                    range1 = true;
                }

                // SPECIAL ZONES CONTROLLER
                int specialRead = Random.Range(0, 100);
                List<GameObject> newZone;

                int zoneIndex;

                if(specialRead <= SpecialZoneChance && range1 == false && sZones.Count != 0){
                    newZone = sZones;
                    zoneIndex = Random.Range(0, sZones.Count );
                } else {
                    newZone = zones;
                    zoneIndex = Random.Range(0, newZone.Count );
                }
                
                // END OF SPECIAL ZONES CONTROLLER
                // ONLY AFFECT N ZONES IN THIS CASE

                GameObject zoneClone2 = Instantiate(range1 ? zones[14] : newZone[zoneIndex], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone2.transform.parent = presenceZone.transform;
                zoneClone2.tag = "E";

                GameObject zoneClone1 = Instantiate(range1 ? zones[14] : zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone1.transform.parent = presenceZone.transform;
                zoneClone1.tag = "NE";

                GameObject zoneClone3 = Instantiate(range1 ? zones[14] : zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone3.transform.parent = presenceZone.transform;
                zoneClone3.tag = "SE";
            } else if (hit.collider.tag == "W")
            {
                Destroy (GameObject.FindWithTag("NE"));
                Destroy (GameObject.FindWithTag("E"));
                Destroy (GameObject.FindWithTag("SE"));

                if(hit.collider.name.Contains("s_") && sZones.Count != 0){
                    // DELETAR DO ARRAY DE ESPECIAIS SE PISAR
                    // VERIFICAR O COUNT PODE ESTAR COM PROBLEMA NA CONTAGEM
                    for (int i = 0; i < sZones.Count; i++) {
                        if(hit.collider.name.Contains(sZones[i].gameObject.name)){
                            sZones.Remove(sZones[i]);
                        }
                    }
                }

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

                hit.collider.tag = "Z";

                bool range1 = false;
                if(player.position.x < -15 && player.position.x > -200 && player.position.z < -200 && player.position.z > -400){
                    range1 = true;
                }

                // SPECIAL ZONES CONTROLLER
                int specialRead = Random.Range(0, 100);
                List<GameObject> newZone;

                int zoneIndex;

                if(specialRead <= SpecialZoneChance && range1 == false && sZones.Count != 0){
                    newZone = sZones;
                    zoneIndex = Random.Range(0, sZones.Count );
                } else {
                    newZone = zones;
                    zoneIndex = Random.Range(0, newZone.Count );
                }
                
                // END OF SPECIAL ZONES CONTROLLER
                // ONLY AFFECT N ZONES IN THIS CASE

                GameObject zoneClone2 = Instantiate(range1 ? zones[14] : newZone[zoneIndex], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone2.transform.parent = presenceZone.transform;
                zoneClone2.tag = "W";

                GameObject zoneClone1 = Instantiate(range1 ? zones[14] : zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone1.transform.parent = presenceZone.transform;
                zoneClone1.tag = "NW";

                GameObject zoneClone3 = Instantiate(range1 ? zones[14] : zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone3.transform.parent = presenceZone.transform;
                zoneClone3.tag = "SW";
            } else if (hit.collider.tag == "NE")
            {
                Destroy (GameObject.FindWithTag("NW"));
                Destroy (GameObject.FindWithTag("W"));
                Destroy (GameObject.FindWithTag("SW"));
                Destroy (GameObject.FindWithTag("S"));
                Destroy (GameObject.FindWithTag("SE"));

                GameObject N = GameObject.FindWithTag("N");
                N.tag = "W";
                GameObject E = GameObject.FindWithTag("E");
                E.tag = "S";
                GameObject Z = GameObject.FindWithTag("Z");
                Z.tag = "SW";

                hit.collider.tag = "Z";

                GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone1.transform.parent = presenceZone.transform;
                zoneClone1.tag = "NW";

                GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone2.transform.parent = presenceZone.transform;
                zoneClone2.tag = "N";

                GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone3.transform.parent = presenceZone.transform;
                zoneClone3.tag = "NE";

                GameObject zoneClone4 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone4.transform.parent = presenceZone.transform;
                zoneClone4.tag = "E";

                GameObject zoneClone5 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone5.transform.parent = presenceZone.transform;
                zoneClone5.tag = "SE";
            } else if (hit.collider.tag == "SE")
            {
                Destroy (GameObject.FindWithTag("NE"));
                Destroy (GameObject.FindWithTag("N"));
                Destroy (GameObject.FindWithTag("NW"));
                Destroy (GameObject.FindWithTag("W"));
                Destroy (GameObject.FindWithTag("SW"));

                GameObject S = GameObject.FindWithTag("S");
                S.tag = "W";
                GameObject E = GameObject.FindWithTag("E");
                E.tag = "N";
                GameObject Z = GameObject.FindWithTag("Z");
                Z.tag = "NW";

                hit.collider.tag = "Z";

                GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone1.transform.parent = presenceZone.transform;
                zoneClone1.tag = "NE";

                GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone2.transform.parent = presenceZone.transform;
                zoneClone2.tag = "E";

                GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone3.transform.parent = presenceZone.transform;
                zoneClone3.tag = "SE";

                GameObject zoneClone4 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone4.transform.parent = presenceZone.transform;
                zoneClone4.tag = "S";

                GameObject zoneClone5 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone5.transform.parent = presenceZone.transform;
                zoneClone5.tag = "SW";
            } else if (hit.collider.tag == "SW")
            {
                Destroy (GameObject.FindWithTag("NE"));
                Destroy (GameObject.FindWithTag("N"));
                Destroy (GameObject.FindWithTag("NW"));
                Destroy (GameObject.FindWithTag("E"));
                Destroy (GameObject.FindWithTag("SE"));

                GameObject S = GameObject.FindWithTag("S");
                S.tag = "E";
                GameObject W = GameObject.FindWithTag("W");
                W.tag = "N";
                GameObject Z = GameObject.FindWithTag("Z");
                Z.tag = "NE";

                hit.collider.tag = "Z";

                GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone1.transform.parent = presenceZone.transform;
                zoneClone1.tag = "SE";

                GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone2.transform.parent = presenceZone.transform;
                zoneClone2.tag = "S";

                GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone3.transform.parent = presenceZone.transform;
                zoneClone3.tag = "SW";

                GameObject zoneClone4 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone4.transform.parent = presenceZone.transform;
                zoneClone4.tag = "NW";

                GameObject zoneClone5 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone5.transform.parent = presenceZone.transform;
                zoneClone5.tag = "W";
            } else if (hit.collider.tag == "NW")
            {
                Destroy (GameObject.FindWithTag("NE"));
                Destroy (GameObject.FindWithTag("S"));
                Destroy (GameObject.FindWithTag("SW"));
                Destroy (GameObject.FindWithTag("E"));
                Destroy (GameObject.FindWithTag("SE"));

                GameObject N = GameObject.FindWithTag("N");
                N.tag = "E";
                GameObject W = GameObject.FindWithTag("W");
                W.tag = "S";
                GameObject Z = GameObject.FindWithTag("Z");
                Z.tag = "SE";

                hit.collider.tag = "Z";

                GameObject zoneClone1 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z - zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone1.transform.parent = presenceZone.transform;
                zoneClone1.tag = "SW";

                GameObject zoneClone2 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone2.transform.parent = presenceZone.transform;
                zoneClone2.tag = "NW";

                GameObject zoneClone3 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x - zoneSize,0,hit.collider.gameObject.transform.position.z), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone3.transform.parent = presenceZone.transform;
                zoneClone3.tag = "W";

                GameObject zoneClone4 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone4.transform.parent = presenceZone.transform;
                zoneClone4.tag = "N";

                GameObject zoneClone5 = Instantiate(zones[Random.Range(0, zones.Count - 1)], new Vector3(hit.collider.gameObject.transform.position.x + zoneSize,0,hit.collider.gameObject.transform.position.z + zoneSize), hit.collider.gameObject.transform.rotation) as GameObject;
                zoneClone5.transform.parent = presenceZone.transform;
                zoneClone5.tag = "NE";
            }
        }
    }
}