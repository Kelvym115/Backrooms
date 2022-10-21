using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int chanceOfSpawn = 5;
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        GameObject checkEnemy = GameObject.FindWithTag("Enemy");
        int randomNum = Random.Range(0, 100);

        if(checkEnemy == null && randomNum <= chanceOfSpawn){
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z), gameObject.transform.rotation) as GameObject;
            enemy.transform.parent = gameObject.transform;
            Debug.Log("Enemy spawned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}