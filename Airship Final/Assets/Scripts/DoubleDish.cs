using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDish : MonoBehaviour
{
    public float reloadBuff = 30f;
    private GameObject closestTurret;
    private bool reduced;

    // Start is called before the first frame update
    void Start()
    {
        closestTurret = FindClosestTurret();

        foreach (var barrel in closestTurret.GetComponentsInChildren<TurretGun>()) {
            if (barrel.reloadTime >= reloadBuff) {
                barrel.reloadTime -= reloadBuff;
            }
        }
        reduced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reduced && GetComponent<EnemyHealth>().health == 0) {
            foreach (var barrel in closestTurret.GetComponentsInChildren<TurretGun>()) {
                barrel.reloadTime += reloadBuff;
            }
            reduced = true;
        }
    }

    public GameObject FindClosestTurret()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Double Turret");
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
