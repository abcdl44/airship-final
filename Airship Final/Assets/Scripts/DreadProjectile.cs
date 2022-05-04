using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Dread Projectile";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player Ship") {
            Destroy(gameObject);
        }
    }
}
