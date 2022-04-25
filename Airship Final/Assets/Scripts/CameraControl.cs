using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject cam;
    public float startDistance = 3f;
    public float rotateRate = 1f;
    public float moveRate = 1f;
    public float minDistance = 1f;
    public float maxDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = gameObject.transform.position + new Vector3(0f, 0f, (maxDistance - minDistance)/2f + minDistance);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.RotateAround(gameObject.transform.position, transform.up, rotateRate * mouseX);

        float mouseY = Input.GetAxis("Mouse Y");
        Vector3.MoveTowards(transform.position, gameObject.transform.position, moveRate * mouseY);

        float distance = Vector3.Distance(transform.position, gameObject.transform.position);
        Vector3 direction = transform.position - gameObject.transform.position;

        Debug.Log(distance);

        if (distance > maxDistance)
        {
            transform.position = direction.normalized * maxDistance + gameObject.transform.position;
        }
        if (distance < minDistance)
        {
            transform.position = direction.normalized * minDistance + gameObject.transform.position;
        }

        transform.LookAt(gameObject.transform);
    }
}
