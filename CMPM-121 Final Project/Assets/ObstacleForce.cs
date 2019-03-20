using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleForce : MonoBehaviour
{
    Rigidbody ball;
    //public bool AxisX, AxisY, AxisZ;
    public float ValueX = 0f, ValueY = 0f, ValueZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        /*
        if (AxisX)
        {
            //ValueX = Random.Range(-5.0f, 5.0f);
            ValueX = 15;
        }
        else
        {
            ball.constraints = RigidbodyConstraints.FreezePositionX;
        }
        if (AxisY)
        {
            //ValueY = Random.Range(-5.0f, 5.0f);
            ValueY = 15;
        }
        else
        {
            ball.constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (AxisZ)
        {
            //ValueZ = Random.Range(10.0f, 20.0f);
            ValueZ = 15;
        }
        else
        {
            ball.constraints = RigidbodyConstraints.FreezePositionZ;
        }
        */
        ball.AddForce(ValueX, ValueY, ValueZ, ForceMode.Impulse);
    }

    // Update is called once per frame


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float NewX = ball.velocity.x * -2;
            float NewY = ball.velocity.y * -2;
            float NewZ = ball.velocity.z * -2;
            ball.AddForce(NewX, NewY, NewZ, ForceMode.Impulse);
        }
    }
}
