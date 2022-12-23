using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource walkingSound;
    public AudioSource runningSound;

    private bool isWalkingW;
    private bool isWalkingA;
    private bool isWalkingS;
    private bool isWalkingD;

    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        isWalkingW = false;
        isWalkingA = false;
        isWalkingS = false;
        isWalkingD = false;

        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            isRunning = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            if(isWalkingW == false){
                isWalkingW = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            if(isWalkingA == false){
                isWalkingA = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            if(isWalkingS == false){
                isWalkingS = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if(isWalkingD == false){
                isWalkingD = true;
            }
        }


        if (Input.GetKeyUp(KeyCode.W)) {
            if(isWalkingW){
                isWalkingW = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            if(isWalkingA){
                isWalkingA = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            if(isWalkingS){
                isWalkingS = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            if(isWalkingD){
                isWalkingD = false;
            }
        }

        if (isWalkingW || isWalkingA || isWalkingS || isWalkingD) {
            if(isRunning){
                walkingSound.Stop();
                if (!runningSound.isPlaying){
                    runningSound.Play();
                }
            } else {
                runningSound.Stop();
                if (!walkingSound.isPlaying){
                    walkingSound.Play();
                }
            }
        }

        if (!isWalkingW && !isWalkingA && !isWalkingS && !isWalkingD) {
            walkingSound.Stop();
            runningSound.Stop();
        }
    }
}
