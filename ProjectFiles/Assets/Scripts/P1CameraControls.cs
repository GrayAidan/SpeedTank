using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1CameraControls : MonoBehaviour
{
    private Vector3 rotation; //the rotation that is used to move the camera

    public float rotataionSpeed;

    public Transform playerTank;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("j"))
        {
            rotation = new Vector3(0, -1 * rotataionSpeed, 0);
            transform.position = new Vector3(playerTank.position.x, transform.position.y, playerTank.position.z);
        }
        else if (Input.GetKey("l"))
        {
            rotation = new Vector3(0, 1 * rotataionSpeed, 0);
            transform.position = new Vector3(playerTank.position.x, transform.position.y, playerTank.position.z);
        }
        else
        {
            rotation = new Vector3(0, 0, 0);
        }

        transform.Rotate(rotation);

    }

}
