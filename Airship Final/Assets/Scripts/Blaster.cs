using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public int offset = 10; //Imagined forward distance the gun looks to
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Makes blaster look at crosshair
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, offset));

        transform.LookAt(wantedPos);

        //Hides blaster outside of aiming mode since it's not aligned with the actual ship model
        if (Input.GetKey(KeyCode.LeftShift)) {
             this.GetComponent<Renderer>().enabled = true;
        } else {
            this.GetComponent<Renderer>().enabled = false;
        }
    }
}
