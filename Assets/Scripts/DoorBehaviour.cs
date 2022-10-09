using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public bool isOpen;

    void Start()
    {
        isOpen = false;
    }

    void DoorInteraction()
    {
        if(isOpen)
        {
            isOpen = false;
        } else {
            isOpen = false;
        }
    }
}
