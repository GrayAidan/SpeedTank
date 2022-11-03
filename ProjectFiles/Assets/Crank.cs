using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{

    public float rotation;
    public float targetRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetRotation = 0;
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            targetRotation = 45;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            targetRotation = 90;
        }
        if (Input.GetKey(KeyCode.End))
        {
            targetRotation = 135;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetRotation = 180;
        }
        if (Input.GetKey(KeyCode.Home))
        {
            targetRotation = 225;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            targetRotation = 270;
        }
        if (Input.GetKey(KeyCode.PageUp)) 
        {
            targetRotation = 315;
        }

        rotation = Mathf.LerpAngle(rotation, targetRotation, Time.deltaTime);
        transform.rotation = Quaternion.Euler(-90, rotation, 0);
    }
}
