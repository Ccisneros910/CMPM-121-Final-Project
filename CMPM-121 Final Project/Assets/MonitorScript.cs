using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorScript : MonoBehaviour
{
    public Material screen;
    private bool doorIsLocked;

    // Start is called before the first frame update
    private void Start()
    {
        doorIsLocked = true;
        //screen.color = Color.red;
    }
    // Update is called once per frame
    void Update()
    {
        if (doorIsLocked == false)
        {
            screen.color = Color.green;
        }
    }

    void unlockDoor()
    {
        doorIsLocked = false;
    }
}
