using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlaster : MonoBehaviour
{
    public GameObject projectile;
    public float reloadTime;
    private float currReload;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ship");
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
            obj.GetComponent<ProjectileInfo>().direction = -transform.forward;
            currReload = reloadTime;
        }
    }
}
