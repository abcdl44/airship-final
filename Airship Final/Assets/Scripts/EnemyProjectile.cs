using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    AudioSource sound;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy Projectile";
        sound = GetComponent<AudioSource>();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player Ship") {
            sound.clip = clips[Random.Range(0, clips.Length)];
            sound.Play();
            
            Destroy(gameObject);
        }
    }
}
