using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaBehaviour : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform player;

    //public Transform[] waypoints;

    //private int waypointIndex;
    private float dist;
    private float playerDist;
    private int chaseDist;
    //private GameObject mummy;
    //private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        chaseDist = 10;
    }

    // Update is called once per frame
    void Update()
    {
        playerDist = Vector3.Distance(transform.position, player.position);

        if(playerDist <= chaseDist)
        {
            chaseDist = 25;
            Chase();
        }
    }

    void Chase()
    {
        // enemy.SetDestination(player.position);
        enemy.SetDestination(player.position);
    }
}
