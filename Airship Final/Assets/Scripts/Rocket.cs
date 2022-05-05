using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Transform target;
    public float speed = 6f;
    ParticleSystem explosion;

    AudioSource beep;
    AudioSource boom;
    public AudioClip[] booms;

    float time;

    private void Start()
    {
        gameObject.tag = "Rocket";
        target = GameObject.Find("Player Ship").transform;
        explosion = GetComponent<ParticleSystem>();
        explosion.Stop();

        beep = (AudioSource)GetComponents(typeof(AudioSource))[0];
        boom = (AudioSource)GetComponents(typeof(AudioSource))[1];

        time = 0;
    }
 
    private void Update()
    {
        time += Time.deltaTime;

        if (time > .2f)
        {
            beep.Play();
            time = 0;
        }
        
        gameObject.transform.LookAt(target);
        gameObject.transform.Rotate(90,0,0);

        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Player Projectile" || other.collider.tag == "Rocket" || other.collider.tag == "Player Ship") {
            StartCoroutine(Exploder());
        }
    }

    IEnumerator Exploder() {
        boom.volume = 1.0f;
        boom.clip = booms[Random.Range(0, booms.Length)];
        boom.Play();

        if (explosion.isStopped) {
            explosion.Play();
        }
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
