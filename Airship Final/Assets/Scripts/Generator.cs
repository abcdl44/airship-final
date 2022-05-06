using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float reloadBuff = 2f;
    private GameObject closestShip;
    private bool reduced;

    // Start is called before the first frame update
    void Start()
    {
        closestShip = FindClosestShip();

        foreach (var blaster in closestShip.GetComponentsInChildren<EnemyBlaster>()) {
                blaster.reloadTime /= reloadBuff;
        }
        reduced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reduced && GetComponent<EnemyHealth>().health == 0) {
            foreach (var blaster in closestShip.GetComponentsInChildren<EnemyBlaster>()) {
                blaster.reloadTime *= reloadBuff;
            }
            reduced = true;
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
