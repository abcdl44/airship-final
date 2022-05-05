using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadProjectile : MonoBehaviour
{
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Dread Projectile";
        sound = gameObject.GetComponent<AudioSource>();
        sound.loop = true;
        sound.Play();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player Ship") {
            Destroy(gameObject);
        }
    }
}
