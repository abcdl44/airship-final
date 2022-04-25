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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerShip.transform.position - new Vector3(0f, 0f, maxDistance);
        currentDistance = maxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.RotateAround(playerShip.transform.position, transform.up, rotateRate * mouseX);

        if (Input.GetKey(KeyCode.LeftControl)) //currently broken, idk why
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

        Vector3 direction = transform.position - playerShip.transform.position;

        transform.position = direction.normalized * currentDistance + playerShip.transform.position;
        
/*
        if (currentDistance > maxDistance)
        {
            
        }
        if (distance < minDistance)
        {
            transform.position = direction.normalized * minDistance + playerShip.transform.position;
        }*/



        transform.position = new Vector3(transform.position.x, playerShip.transform.position.y, transform.position.z);
        transform.LookAt(playerShip.transform);
    }
}
