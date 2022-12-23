using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemy_behaviour : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform player;
    public GameObject audioData;
    private AudioSource audioSource;
    private bool audioFlag;

    //public Transform[] waypoints;

    //private int waypointIndex;
    private float dist;
    private float playerDist;
    private int chaseDist;
    private bool isNav;
    private bool isChasing;
    //private GameObject mummy;
    //private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.Find("Player_Test");
        if(playerObj == null){
            // destroi o inimigo se o objeto do jogador não existir ainda
            Destroy(gameObject);
        }
        player = playerObj.transform;

        isChasing = false;

        audioFlag = true;
        audioSource = audioData.GetComponent<AudioSource>();
        //mummy = GameObject.Find("Mummy_1_Weaponless");
        //_anim = mummy.GetComponent<Animator>();
        //_anim.SetTrigger("Walk");

        chaseDist = 25;
        isNav = true;

        //waypointIndex = 0;
        //transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshPath path = new NavMeshPath();
        //dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        playerDist = Vector3.Distance(transform.position, player.position);

        if(playerDist <= chaseDist)
        {
            if(isNav){
                enemy.CalculatePath(player.position, path);
                chaseDist = 25;
                isChasing = true;
                //_anim.SetTrigger("Run");
                Chase();

            }
        } else if (isChasing && playerDist >= chaseDist * 1.5f)
        {
            Destroy(gameObject);
        }

        if (isNav){
            if (path.status == NavMeshPathStatus.PathPartial)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                isNav = false;
                StartCoroutine(waitForNav(2f));
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * 5);
        }

        if (playerDist > 150) {
            Debug.Log("Enemy Missed!");
            Destroy(gameObject);
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
        if(audioFlag){
            PlayAudio();
        }
        enemy.SetDestination(player.position);
    }

    void PlayAudio()
    {
        audioSource.Play();
        audioFlag = false;
    }

    private IEnumerator waitForNav(float waitTime)
    {       
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        isNav = true;
    }

    void OnCollisionEnter(Collision col){
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player"){
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
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
