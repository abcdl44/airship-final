using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    public Vector3 direction;
    public float thrust = 10000f; // No idea how this actually translates to velocity mathematically

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Debug.Log(direction * thrust);
        rb.AddForce(direction * thrust);
    }

    // Unimplemented
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("xddd");
    }
}
