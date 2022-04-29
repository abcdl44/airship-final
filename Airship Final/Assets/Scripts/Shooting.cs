using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerShip;
    public GameObject projectile;
    public int gunCount;
    public float reloadTime;
    public float shipLength = 1f; // If we ever get ship customization we'll need to change this

    private float[] reloadsLeft;
    private float[] reloadsRight;

    private float[] gunPositions;

    void Start()
    {
        // default values should be 0
        reloadsLeft = new float[gunCount];
        reloadsRight = new float[gunCount];

        // so the guns don't all fire from the same spot
        gunPositions = new float[gunCount];
        float l = shipLength/(gunCount + 2);
        for (int x = 0; x < gunCount; x++)
        {
            gunPositions[x] = shipLength;
            shipLength += shipLength / (gunCount + 2);
        }

    }


    // tl;dr left click to shoot once, right click to fire all available guns
    // each gun has its own independent reload timer, when timer is 0 then gun is ready to pew pew
    void Update()
    {
        // tick reload timers, might be inefficient but I'll only care if it lags
        float t = Time.deltaTime;
        for (int i = 0; i < gunCount; i++)
        {
            reloadsLeft[i] -= t;
            reloadsRight[i] -= t;
            if (reloadsLeft[i] < 0)
            {
                reloadsLeft[i] = 0f;
            }
            if (reloadsRight[i] < 0)
            {
                reloadsRight[i] = 0f;
            }
        }

        if (Input.GetMouseButtonDown(0)) // left click
        {
            for (int i = 0; i < gunCount; i++)
            {
                if (FireGun(i, IsLeft()))
                {
                    break;
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) // left click has priority over right click
        {
            for (int i = 0; i < gunCount; i++)
            {
                FireGun(i, IsLeft());
            }
        }
    }

    // Returns whether the camera is facing closer to the ship's local left or right COPY PASTE FROM CAMERA
    private bool IsLeft()
    {
        float angle = Vector3.SignedAngle(transform.forward, playerShip.transform.forward, playerShip.transform.up);
        if (angle < 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    // Attempts to fire the gun corresponding to proper number and side.
    // Returns success/fail
    // On success sets reload timer and instantiates projectile
    private bool FireGun(int x, bool isLeft)
    {
        if (isLeft && reloadsLeft[x] == 0)
        {
            // fires projectile, with a little bit of offset based on gunPosition, and adjusts it so it doesn't clip the ship on spawn
            // offset and direction not functional, rather than firing off of camera, it should fire off of ship left/right
            Vector3 pos = playerShip.transform.position - playerShip.transform.forward * gunPositions[x] + transform.forward * .25f;
            GameObject obj = Instantiate(projectile, pos, Quaternion.identity);

            obj.GetComponent<ProjectileInfo>().direction = transform.forward;

            reloadsLeft[x] = reloadTime;
            return true;
        }
        if (!isLeft && reloadsRight[x] == 0)
        {
            Vector3 pos = playerShip.transform.position - playerShip.transform.forward * gunPositions[x] + transform.forward * .25f;
            GameObject obj = Instantiate(projectile, pos, Quaternion.identity);

            obj.GetComponent<ProjectileInfo>().direction = transform.forward;

            reloadsRight[x] = reloadTime;
            return true;
        }
        return false;
    } 
}