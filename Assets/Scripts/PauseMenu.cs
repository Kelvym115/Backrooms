using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    private GameObject pauseLabel;

    void Start()
    {
        pauseLabel = GameObject.Find("PauseMenuLabel");
        pauseLabel.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
        }

        if (isPaused){
            pauseLabel.SetActive(true);
        } else {
            pauseLabel.SetActive(false);
        }
    }

    public void Quit()
    {
        if (isPaused){
            Application.Quit();
        }
    }
}
