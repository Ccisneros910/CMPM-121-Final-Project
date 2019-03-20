using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator anim;
    public AudioClip DoorUnlockedSound;
    public AudioSource DoorSound;
    public bool DoorIsLocked;
    public ParticleSystem DoorFrame;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        DoorSound = GetComponent<AudioSource>();
        //Debug.Log("game start");
        //DoorFrame = GetComponent<ParticleSystem>();
        if (DoorIsLocked == false)
        {
            DoorSound.clip = DoorUnlockedSound;
            DoorFrame.Stop();
            DoorFrame.startColor = new Color(0, 1, 0);
            DoorFrame.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DoorSound.Play();
        if (other.name == "SpaceMan" && DoorIsLocked == false)
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
        if(other.name == "SpaceMan" && DoorIsLocked == false)
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
