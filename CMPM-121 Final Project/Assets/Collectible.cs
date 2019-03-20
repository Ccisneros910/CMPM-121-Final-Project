using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public ParticleSystem lure, collected;
    public Renderer skin;
    public Collider trigger;
    public Slider fuelSlider;
    // Start is called before the first frame update
    void Start()
    {
        skin = GetComponent<Renderer>();
        trigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            lure.Stop();
            collected.Play();
            skin.enabled = false;
            trigger.enabled = false;
            fuelSlider.value = fuelSlider.maxValue;
        }
    }
}
