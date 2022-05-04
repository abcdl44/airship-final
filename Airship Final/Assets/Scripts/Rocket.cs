using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Transform target;
    public float speed;
    ParticleSystem explosion;

    private void Start()
    {
        gameObject.tag = "Rocket";
        target = GameObject.Find("Player Ship").transform;
        explosion = GetComponent<ParticleSystem>();
        explosion.Stop();
    }
 
    private void Update()
    {
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
        if (explosion.isStopped) {
            explosion.Play();
        }
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
