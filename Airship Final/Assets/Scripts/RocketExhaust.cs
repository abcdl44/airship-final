using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExhaust : MonoBehaviour
{
    ParticleSystem exhaust;
    GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        exhaust = GetComponent<ParticleSystem>();
        //ship = transform.parent.gameObject;
        exhaust.Play();
    }
}
