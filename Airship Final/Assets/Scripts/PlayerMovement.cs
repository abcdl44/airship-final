using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float pitchSpeed;
    public float rotateSpeed;
    public float maxSpeed;
    public float accelRate;
    public float maxAccel;

    private int speedLevel;
    private float[] speeds;
    private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speedLevel = 4; // 7 levels of speed - (Full, 3/4, Half, 1/4, Still, -1/2, -Full), 0-6 respectively
        speeds = new float[] { maxSpeed, .75f * maxSpeed, .5f * maxSpeed, .25f * maxSpeed, 0, -.25f * maxSpeed, -.5f * maxSpeed };
        speed = speeds[speedLevel];
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-.5f * pitchSpeed, 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(.5f * pitchSpeed, 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, .5f * pitchSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -.5f * pitchSpeed, Space.Self);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (speedLevel > 0)
            {
                speedLevel -= 1;
            }          
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (speedLevel < 6)
            {
                speedLevel += 1;
            }
        }

        // Goal of acceleration/deaccel: slow down/speed up to meet targeted speed rather than immediate change
        // may need tinkering for accurate physics but it's a working prototype
        speed = speeds[speedLevel];
        Vector3 target = speed * transform.forward;

        Vector3 change = target - rb.velocity;
        Vector3 accel = change / (accelRate);
        accel = Vector3.ClampMagnitude(accel, maxAccel);
        rb.AddForce(accel, ForceMode.Acceleration);


        //Debug.Log(speedLevel);
        Debug.Log(transform.forward);
        //Debug.Log(rb.velocity.normalized);
    }
}
