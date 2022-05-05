using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangerSpawn : MonoBehaviour
{
    public GameObject ship;
    public float reloadTime;
    private float currReload;
    public float delay;
    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= delay)
        {
            float t = Time.deltaTime;
            currReload -= t;
            if (currReload < 0)
            {
                currReload = 0f;
            }
            if (currReload == 0)
            {
                sound.volume = .7f;
                sound.Play();
                GameObject obj = Instantiate(ship, transform.position, Quaternion.identity);
                currReload = reloadTime;
            }
        }
    }
}
