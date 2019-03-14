using UnityEngine;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
    //public AudioClip highlight;
    public AudioClip click;
    private  Button thisB;
    //private AudioSource h { get {return GetComponent<AudioSource>(); } }
    private AudioSource c { get {return GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        thisB = GetComponent<Button>();
        thisB.onClick.AddListener(PlayClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayClip()
    {
        c.PlayOneShot(click);
    }
}
