using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Texture2D crosshair;
    public float maxHorizontalDegrees = 60f; // 90 = 180 degree view
    public float maxVerticalDegrees = 45f;
    public float aimRate = 5f;

    public bool released; // don't edit in unity pls

    private float currHorz;
    private float currVert;

    // Camera object; ship; true if looking left else false
    public IEnumerator Aim(GameObject cam, GameObject ship, bool isLeft) {
        released = false;
        currHorz = 0f;
        currVert = 0f;


        // Defines crosshair. Can we lock this to the center of the screen? Cursor.lockState doesn't work idk
        Vector2 cursorOffset = new Vector2(crosshair.width / 2, crosshair.height / 2);
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.ForceSoftware);


        while (!released) {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Sets camera to current position of ship every time.
            cam.transform.position = ship.transform.position;
            cam.transform.rotation = ship.transform.rotation;

            if (isLeft) { 
                cam.transform.Rotate(0, -90f, 0); // left
            }
            else
            {
                cam.transform.Rotate(0, 90f, 0); // other left
            }
            cam.transform.position += cam.transform.forward * .5f;

            // controls left and right movement of camera while aiming within the limits defined by maxHorz/Vert
            if (mouseX != 0)
            {
                currHorz += mouseX * aimRate;
                if (currHorz > maxHorizontalDegrees)
                {
                    currHorz = maxHorizontalDegrees - 0.1f;
                }
                if (currHorz < -maxHorizontalDegrees)
                {
                    currHorz = -maxHorizontalDegrees + 0.1f;
                }
            }
            if (mouseY != 0)
            {
                currVert += -mouseY * aimRate;
                if (currVert > maxVerticalDegrees)
                {
                    currVert = maxVerticalDegrees - 0.1f;
                }
                if (currVert < -maxVerticalDegrees)
                {
                    currVert = -maxVerticalDegrees + 0.1f;
                }
            }

            // The actual rotation. No touch.
            cam.transform.Rotate(currVert, currHorz, 0);

            yield return null;
        }

        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        yield break;
    }
}
