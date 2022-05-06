using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlaster : MonoBehaviour
{
    public GameObject projectile;
    public float reloadTime;
   
    private float currReload;
    private GameObject player;

    AudioSource shootSound;
    float coneOfFire = 10f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ship");
        shootSound = GetComponent<AudioSource>();
        shootSound.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeSelf) {
            transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
        }
        float t = Time.deltaTime;
        currReload -= t;
        if (currReload < 0) {
            currReload = 0f;
        }
    }

    public void Shoot() {
        if (currReload == 0) { 
            GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);

            Quaternion randAim = Quaternion.Euler(Random.Range(-coneOfFire, coneOfFire), Random.Range(-coneOfFire, coneOfFire), 0);

            obj.GetComponent<ProjectileInfo>().direction = randAim  * - transform.forward;
            currReload = reloadTime;
            shootSound.Play();
        }
    }
}
