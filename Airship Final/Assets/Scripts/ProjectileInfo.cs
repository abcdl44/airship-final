using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    public Vector3 direction;
    public float thrust = 100f; // No idea how this actually translates to velocity mathematically
    AudioSource pew;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * thrust);
        pew = GetComponent<AudioSource>();
        pew.Play();
    }
}
