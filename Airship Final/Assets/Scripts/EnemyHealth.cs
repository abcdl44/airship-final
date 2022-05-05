using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    ParticleSystem explosion;
    public EnemyHealthBar healthBar;

    AudioSource sound;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {  
        healthBar.SetHealth(health, maxHealth);
        explosion = GetComponent<ParticleSystem>();
        explosion.Stop();

        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            StartCoroutine(Exploder());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player Projectile") {
            health -= 10;
            healthBar.SetHealth(health, maxHealth);

            sound.volume = .3f;
            sound.spatialBlend = 0.3f;
            sound.clip = clips[Random.Range(0, clips.Length)];
            sound.Play();

            Destroy(other.gameObject);
        }
    }

    IEnumerator Exploder() {
        yield return new WaitForSeconds(.2f);

        sound.volume = 1.0f;
        sound.spatialBlend = 0.1f;
        sound.clip = clips[Random.Range(0, clips.Length)];
        sound.Play();

        explosion.Play();
        yield return new WaitForSeconds(1);     

        gameObject.SetActive(false);
    }
}
