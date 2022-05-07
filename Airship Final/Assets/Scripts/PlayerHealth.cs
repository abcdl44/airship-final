using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 200;
    GameObject player;
    ParticleSystem explosion;
    public Text displayHealth;

    AudioSource ow;
    public AudioClip[] explosions;

    public GameObject prefs;
    private GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.FindGameObjectWithTag("Game Over");
        gameOver.SetActive(false);
        health = prefs.GetComponent<Variables>().health;

        player = GameObject.Find("Player Ship");
        explosion = GetComponent<ParticleSystem>();
        explosion.Stop();

        ow = (AudioSource)GetComponents(typeof(AudioSource))[2];
        displayHealth.color = new Color32(255,179,58,255);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);
        if (health <= 0) {
            displayHealth.gameObject.SetActive(false);
            StartCoroutine(Exploder());
        }
        displayHealth.text = health.ToString();

        if (health <= 50) {
            displayHealth.color = Color.red;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Enemy Projectile") {
            health -= 10;
        }

        if (other.collider.tag == "Rocket") {
            health -= 50;
        }

        if (other.collider.tag == "Dread Projectile") {
            health -= 40;
        }
    }

    IEnumerator Exploder() {
        yield return new WaitForSeconds(.5f);

        ow.clip = explosions[Random.Range(0, explosions.Length)];
        ow.spatialBlend = 0.0f;
        ow.volume = 1.0f;
        ow.Play();

        explosion.Play();   
        yield return new WaitForSeconds(1);

        AudioListener.pause = true;
        gameOver.SetActive(true);
        player.SetActive(false);
    }
}