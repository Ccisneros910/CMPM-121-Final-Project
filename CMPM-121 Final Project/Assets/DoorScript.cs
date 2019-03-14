using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("game start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SpaceMan")
        {
            if (this.tag == "door1")
            {
                anim.Play("door_1_open");
            }

            if (this.tag == "door2")
            {
                anim.Play("door_2_open");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "SpaceMan")
        {
            if (this.tag == "door1")
            {
                anim.Play("door_1_close");
            }

            if (this.tag == "door2")
            {
                anim.Play("door_2_close");
            }
        }
    }


}
