using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1CameraControls : MonoBehaviour
{
    private Vector3 rotation; //the rotation that is used to move the camera

    public float rotataionSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("j"))
        {
            rotation = new Vector3(0, -1 * rotataionSpeed, 0);
        }
        else if (Input.GetKey("l"))
        {
            rotation = new Vector3(0, 1 * rotataionSpeed, 0);
        }
        else
        {
            rotation = new Vector3(0, 0, 0);
        }

        transform.Rotate(rotation);

    }
}
