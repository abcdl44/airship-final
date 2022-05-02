using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    ParticleSystem explosion;
    public EnemyHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {  
        healthBar.SetHealth(health, maxHealth);
        explosion = GetComponent<ParticleSystem>();
        explosion.Stop();
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
        //Debug.Log(health);
        if (other.collider.tag == "Player Projectile") {
            health -= 10;
            healthBar.SetHealth(health, maxHealth);
        }
    }

    IEnumerator Exploder() {
        explosion.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
