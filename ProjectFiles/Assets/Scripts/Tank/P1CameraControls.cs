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
        rotation = new Vector3(0, Input.GetAxis("Horizontal") * rotataionSpeed, 0);
        transform.position = new Vector3(playerTank.position.x, transform.position.y, playerTank.position.z);

        transform.Rotate(rotation);

    }

}
