using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    GameObject player;
    ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ship");
        explosion = GetComponent<ParticleSystem>();
        explosion.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (health <= 0) {
            StartCoroutine(Exploder());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        health -= 10;
    }

    IEnumerator Exploder() {
        explosion.Play();
        yield return new WaitForSeconds(1);
        player.SetActive(false);
    }
}
