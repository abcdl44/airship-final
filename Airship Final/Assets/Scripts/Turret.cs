using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject player;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ship");
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
