using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    private AudioSource doorUnlocked;
    public GameObject door;
    DoorScript door_script;
    List<GameObject> componenets;
    public ParticleSystem lure;
    public ParticleSystem unlockedReaction;

    // Start is called before the first frame update
    void Start()
    {   
        door_script = door.GetComponent<DoorScript>();
        //Debug.Log(door_script.DoorIsLocked);
        doorUnlocked = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("keypad reached");
        if(other.gameObject.name == "SpaceMan" && door_script.DoorIsLocked == true)
        {
            //if (Input.GetKeyDown(KeyCode.I))
            //{
            doorUnlocked.Play();
            door_script.DoorIsLocked = false;
            Debug.Log(door_script.DoorIsLocked);
            door_script.DoorFrame.Stop();
            door_script.DoorFrame.startColor = new Color(0, 1, 0);
            door_script.DoorFrame.Play();
            door_script.DoorSound.clip = door_script.DoorUnlockedSound;
            lure.Stop();
            unlockedReaction.Play();
            //}
        }
    }
}
