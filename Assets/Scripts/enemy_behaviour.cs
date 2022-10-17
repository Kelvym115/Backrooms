using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_behaviour : MonoBehaviour
{
    public NavMeshAgent enemy;
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
        //mummy = GameObject.Find("Mummy_1_Weaponless");
        //_anim = mummy.GetComponent<Animator>();
        //_anim.SetTrigger("Walk");

        chaseDist = 10;

        //waypointIndex = 0;
        //transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        //dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        playerDist = Vector3.Distance(transform.position, player.position);

        if(playerDist <= chaseDist)
        {
            chaseDist = 25;
            //_anim.SetTrigger("Run");
            Chase();
        } 
        // else {
        //     chaseDist = 10;
        //     if(dist < 0.5f)
        //     {
        //         IncreaseIndex();
        //     }
        //     _anim.SetTrigger("Walk");
        //     Patrol();
        // }
    }

    // void Patrol()
    // {
    //     // enemy.SetDestination(player.position);
    //     enemy.SetDestination(waypoints[waypointIndex].position);
    // }

    void Chase()
    {
        // enemy.SetDestination(player.position);
        enemy.SetDestination(player.position);
    }

    // void IncreaseIndex()
    // {
    //     waypointIndex++;
    //     if(waypointIndex >= waypoints.Length)
    //     {
    //         waypointIndex = 0;
    //     }
    //     transform.LookAt(waypoints[waypointIndex].position);
    // }
}
