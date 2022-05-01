using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour
{
    ParticleSystem exhaust;
    GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        exhaust = GetComponent<ParticleSystem>();
        ship = GameObject.Find("Player Ship");
    }

    // Update is called once per frame
    void Update()
    {
        if (ship.GetComponent<PlayerMovement>().speed == 0) {
            exhaust.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        } else {
            if (exhaust.isStopped) {
                exhaust.Play();
            }
        }
        
    }
}
