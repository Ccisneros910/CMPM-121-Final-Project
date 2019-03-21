using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Collectible : MonoBehaviour
{
    public ParticleSystem lure, collected;
    public Renderer skin;
    public Collider trigger;
    public Slider fuelSlider;
    public Text popup;
    // Start is called before the first frame update
    void Start()
    {
        skin = GetComponent<Renderer>();
        trigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && this.name != "projector stars")
        {
            lure.Stop();
            collected.Play();
            skin.enabled = false;
            trigger.enabled = false;
            fuelSlider.value = fuelSlider.maxValue;
        }
        if (other.gameObject.tag == "Player" && this.name == "projector stars")
        {
            StartCoroutine(EndOfGame());
        }
    }

    IEnumerator EndOfGame()
    {
        popup.enabled = true;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
