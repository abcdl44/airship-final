using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float reloadBuff = 2f;
    private GameObject closestShip;

    // Update is called once per frame
    void Update()
    {
        closestShip = FindClosestShip();

        foreach (var blaster in closestShip.GetComponentsInChildren<EnemyBlaster>()) {
            if (blaster.reloadTime == blaster.naturalReload) {
                blaster.reloadTime /= reloadBuff;
            }
        }

        if (GetComponent<EnemyHealth>().health == 0) {
            foreach (var blaster in closestShip.GetComponentsInChildren<EnemyBlaster>()) {
                if (blaster.reloadTime < blaster.naturalReload) {
                    blaster.reloadTime *= reloadBuff;
                }
            }
        }
    }

    public GameObject FindClosestShip()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy Ship");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
