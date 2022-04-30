using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlaster : MonoBehaviour
{
    public GameObject projectile;
    public float reloadTime;
    private float currReload;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - GameObject.Find("Player Ship").transform.position);
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
