using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject cam;
    public Transform playerShip;
    public float startDistance = 3f;
    public float rotateRate = 1f;
    public float moveRate = 1f;
    public float minDistance = 1f;
    public float maxDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerShip.position + new Vector3(0f, 0f, (maxDistance - minDistance)/2f + minDistance);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.RotateAround(playerShip.position, transform.up, rotateRate * mouseX);

        float mouseY = Input.GetAxis("Mouse Y");
        Vector3.MoveTowards(transform.position, playerShip.position, moveRate * mouseY);

        float distance = Vector3.Distance(transform.position, playerShip.position);
        Vector3 direction = transform.position - playerShip.position;

        Debug.Log(distance);

        if (distance > maxDistance)
        {
            transform.position = direction.normalized * maxDistance + playerShip.position;
        }
        if (distance < minDistance)
        {
            transform.position = direction.normalized * minDistance + playerShip.position;
        }

        transform.LookAt(playerShip);
    }
}
