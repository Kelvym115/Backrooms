using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClipingScript : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_Test");
        player.SetActive(false);
    }

    void SpawnPlayer()
    {
        Destroy(gameObject);
        player.SetActive(true);
    }
}