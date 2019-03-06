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

    public float rotationRate = 30;

    public float moveSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Rigidbody>();
        EulerAngleVelocity = new Vector3(0, 10, 0);
        player = GetComponent<Rigidbody>();
        fuelSlider.minValue = 0;
        fuelSlider.maxValue = 100;
        fuelSlider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        float AxisH = Input.GetAxis(turnInputAxisH);
        float AxisV = Input.GetAxis(turnInputAxisV);
        bool moveForward = Input.GetKey(KeyCode.Space);
        bool moveBack = Input.GetKey(KeyCode.LeftShift);
        bool stopMovement = Input.GetKey(KeyCode.X);

        ApplyInput(AxisH, AxisV, moveForward, moveBack, stopMovement);

        transform.Translate(Vector3.forward * 1 * moveSpeed);

        /*
         if (Input.GetKey(KeyCode.A))
         {
            Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);
            player.MoveRotation(player.rotation * deltaRotation);
         }
         */
    }

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
            fuelSlider.value -= 0.1f;
        }
    }

    private void turnV(float input)
    {
        if (input != 0f)
        {
            transform.Rotate(input * rotationRate * Time.deltaTime, 0, 0);
            fuelSlider.value -= 0.1f;
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
            moveSpeed += 0.001f;
            fuelSlider.value -= 0.3f;
        }
    }

    private void moveB(bool input)
    {
        if (input == true & moveSpeed >-.3)
        {
            //transform.Translate(Vector3.forward * -1 * moveSpeed);

            moveSpeed -= 0.001f;
            fuelSlider.value -= 0.3f;
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
                    moveSpeed -= 0.002f;
                }
            }
            else if (moveSpeed < 0)
            {
                while (moveSpeed < 0)
                {
                    moveSpeed += 0.002f;
                }
            }
            moveSpeed = 0f;
            fuelSlider.value -= 3f;
        }
    }


}
