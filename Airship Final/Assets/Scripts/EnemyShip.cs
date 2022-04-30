using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    GameObject player;
    public float shootingRange;
    public float detectionRange;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ship");
        transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
    }

    // Update is called once per frame
    void Update()
    {
        float currDist = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(currDist);

        if (currDist > detectionRange) { //Ship minds its own business if out of range
            transform.position += transform.forward * Time.deltaTime * speed;
        } else if (currDist <= detectionRange && currDist > shootingRange) { //Ship sees you and moves closer to get in weapon range
            transform.LookAt(player.transform.position);
            transform.position += transform.forward * Time.deltaTime * speed;
        } else if (currDist <= detectionRange && currDist <= shootingRange) { //Ship is in range to shoot you, continues to move to match your speed
            transform.LookAt(player.transform.position);
            //transform.position += transform.forward * Time.deltaTime * player.GetComponent<PlayerMovement>().speed*0.75f;
            foreach(var blaster in GetComponentsInChildren<EnemyBlaster>())
            {
                blaster.Shoot();
            }
        }
    }
}
