using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
    public GameObject projectile;
    public float reloadTime;
    private float currReload;
    public float delay;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(reloadTime);
        if (Time.time >= delay) {
            float t = Time.deltaTime;
            currReload -= t;
            if (currReload < 0) {
                currReload = 0f;
            }
            if (currReload == 0) {
                GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);
                currReload = reloadTime;
            }
        }
    }
}
