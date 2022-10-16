using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public List<GameObject> trashList;
    public List<GameObject> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            GameObject trashSpawned = Instantiate(trashList[Random.Range(0, trashList.Count)], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, spawnPoints[i].transform.position.z), gameObject.transform.rotation) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
