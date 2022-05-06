using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject cam;
    public GameObject playerShip;
    public float rotateRate = 1f;
    public float moveRate = 1f;
    public float minDistance = 3f;
    public float maxDistance = 10f;

    private float currentDistance;
    private Vector3 direction;

    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = playerShip.transform.position - new Vector3(0f, 0f, maxDistance);
        currentDistance = maxDistance;
        direction = transform.position - playerShip.transform.position;

        sound = GetComponent<AudioSource>();
        sound.loop = true;
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // On LShift, calls aim coroutine, and suppresses self until LShift release
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cam.GetComponent<Aiming>().StartCoroutine(cam.GetComponent<Aiming>().Aim(cam, playerShip, IsLeft())); 
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cam.GetComponent<Aiming>().released = true;

            Reset(currentDistance, direction);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return;
        }



        float mouseX = Input.GetAxis("Mouse X");
        transform.RotateAround(playerShip.transform.position, transform.up, rotateRate * mouseX);
        if (mouseX != 0)
        {
            direction = transform.position - playerShip.transform.position;
        }


        if (Input.GetKey(KeyCode.LeftControl)) // Allows player to zoom in and out when LCtrl held down
        {
            float mouseY = Input.GetAxis("Mouse Y");
            if (mouseY != 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerShip.transform.position, moveRate * mouseY);
                currentDistance = Vector3.Distance(transform.position, playerShip.transform.position);

                if (currentDistance > maxDistance)
                {
                    currentDistance = maxDistance - .01f;
                }
                if (currentDistance < minDistance)
                {
                    currentDistance = minDistance + .01f;
                }
            }
        }
        Reset(currentDistance, direction);
    }

    // Called whenever the camera needs to get moved back to the position
    private void Reset(float currentDistance, Vector3 direction)
    {
        // Maintains the same distance from camera and ship      
        transform.position = direction.normalized * currentDistance + playerShip.transform.position;

        // Camera focuses on ship, remains same height
        transform.position = new Vector3(transform.position.x, playerShip.transform.position.y, transform.position.z);
        transform.LookAt(playerShip.transform);
    }


    // Returns whether the camera is facing closer to the ship's local left or right
    private bool IsLeft()
    {
        float angle = Vector3.SignedAngle(transform.forward, playerShip.transform.forward, playerShip.transform.up);
        if (angle < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
}
