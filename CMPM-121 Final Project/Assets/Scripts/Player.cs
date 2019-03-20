using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody player;
    private Vector3 EulerAngleVelocity;

    private string turnInputAxisH = "Horizontal";
    private string turnInputAxisV = "Vertical";
    private string moveInput = "Vertical";
    public Slider fuelSlider;
    private float fuelDifference;
    public Text endText;

    public float rotationRate = 45;
    public float moveSpeed;
    private int health;
    public Image[] hearts;
    public ParticleSystem[] airSpray;
    public AudioSource jetPack;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Rigidbody>();
        EulerAngleVelocity = new Vector3(0, 10, 0);
        player = GetComponent<Rigidbody>();
        jetPack = GetComponent<AudioSource>();
        fuelSlider.minValue = 0;
        fuelSlider.maxValue = 100;
        fuelSlider.value = 100;
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float AxisH = Input.GetAxis(turnInputAxisH);
        float AxisV = Input.GetAxis(turnInputAxisV);
        bool moveForward = Input.GetKey(KeyCode.Space);
        bool moveBack = Input.GetKey(KeyCode.LeftShift);
        bool stopMovement = Input.GetKey(KeyCode.X);

        if (fuelSlider.value > 0)
        {
            JetPackControl();
            ApplyInput(AxisH, AxisV, moveForward, moveBack, stopMovement);
        }
        else
        {
            jetPack.Stop();
            for(int i = 0; i < 5; i++)
            {
                airSpray[i].Stop();
            }
        }
        transform.Translate(Vector3.forward * 1 * moveSpeed);

        /*
         if (Input.GetKey(KeyCode.A))
         {
            Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);
            player.MoveRotation(player.rotation * deltaRotation);
         }
         */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bounce")
        {
            moveSpeed = -moveSpeed * 2;
        }
        if (collision.gameObject.tag == "Boundary")
        {
            moveSpeed = -moveSpeed * 0.1f;
        }

        if (collision.gameObject.tag == "damage")
        {
            hearts[health - 1].color = new Color(0.3f, 0.3f, 0.3f);
            health -= 1;
            moveSpeed = -0.02f;
            if(health == 0)
            {
                Debug.Log("GAME OVER");
            }
        }
        /*
        Debug.Log("Tank hit!");
        if (collision.gameObject.tag == "refuel")
        {
            fuelSlider.value = fuelSlider.maxValue;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "projector stars")
        {
            endText.enabled = true;
        }
    }
    /*
    public void onTriggerEnter(Collider other)
    {
        Debug.Log("Tank hit!");
        if (other.gameObject.tag == "refuel")
        {
            fuelSlider.value = fuelSlider.maxValue;
        }
    }
    */
    private void ApplyInput(float H, float V, bool F, bool B, bool S)
    {
        turnH(H);
        turnV(V);
        moveF(F);
        moveB(B);
        stop(S);
    }

    // read each input
    private void turnH(float input)
    {
        if (input != 0f)
        {
            transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
            fuelSlider.value -= 0.01f;
        }
    }

    private void turnV(float input)
    {
        if (input != 0f)
        {
            transform.Rotate(input * rotationRate * Time.deltaTime, 0, 0);
            fuelSlider.value -= 0.01f;
        }
    }

    private void moveF(bool input)
    {
        if (input == true && moveSpeed < .3)
        {
            //transform.Translate(Vector3.forward * 1 * moveSpeed);

            //transform.Translate(Vector3.forward * Time.deltaTime);

            //Vector3 movement = new Vector3(0, 0, Input.GetKey(KeyCode.Space);
            //transform.position = movement * Time.deltaTime;
            //player.AddForce(movement * 25);
            moveSpeed += 0.002f;
            fuelSlider.value -= 0.1f;
        }
    }

    private void moveB(bool input)
    {
        if (input == true & moveSpeed >-.3)
        {
            //transform.Translate(Vector3.forward * -1 * moveSpeed);

            moveSpeed -= 0.002f;
            fuelSlider.value -= 0.1f;
        }
    }

    private void stop(bool input)
    {
        if(input == true)
        {
            if(moveSpeed > 0)
            {
                while(moveSpeed > 0)
                {
                    moveSpeed -= 0.001f;
                }
            }
            else if (moveSpeed < 0)
            {
                while (moveSpeed < 0)
                {
                    moveSpeed += 0.001f;
                }
            }
            player.angularVelocity = Vector3.zero;
            //player.rotation = Vector3.
            fuelSlider.value -= 0.5f;
        }
    }

    void JetPackControl()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.X))
        {
            jetPack.Play();
        }
            if (Input.GetKeyDown(KeyCode.A))
        {
            airSpray[1].Play();
            airSpray[3].Play();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            airSpray[1].Stop();
            airSpray[3].Stop();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            airSpray[0].Play();
            airSpray[2].Play();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            airSpray[0].Stop();
            airSpray[2].Stop();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            airSpray[2].Play();
            airSpray[3].Play();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            airSpray[2].Stop();
            airSpray[3].Stop();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            airSpray[0].Play();
            airSpray[1].Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            airSpray[0].Stop();
            airSpray[1].Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            airSpray[0].Play();
            airSpray[1].Play();
            airSpray[2].Play();
            airSpray[3].Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            airSpray[0].Stop();
            airSpray[1].Stop();
            airSpray[2].Stop();
            airSpray[3].Stop();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            for(int i = 0; i < 5; i++)
            {
                airSpray[i].startSize = 3;
                airSpray[i].startSpeed = 50;
            }
            airSpray[0].Play();
            airSpray[1].Play();
            airSpray[2].Play();
            airSpray[3].Play();
            airSpray[4].Play();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            airSpray[0].Stop();
            airSpray[1].Stop();
            airSpray[2].Stop();
            airSpray[3].Stop();
            airSpray[4].Stop();
            for (int i = 0; i < 5; i++)
            {
                airSpray[i].startSize = 1;
                airSpray[i].startSpeed = 25;
            }

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.X))
        {
            jetPack.Stop();
        }


    }

    private void DamageTaken()
    {

    }
    private void GameOver()
    {

    }
}
