using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2CameraControls : MonoBehaviour
{
    private Vector3 rotation; //the rotation that is used to move the camera

    public float rotataionSpeed;

    public AudioSource _as;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            rotation = new Vector3(0, 0, -1 * rotataionSpeed);
            AudioCheck();
        }
        else if (Input.GetKey("e"))
        {
            rotation = new Vector3(0, 0, 1 * rotataionSpeed);
            AudioCheck();
        }
        else
        {
            rotation = new Vector3(0, 0, 0);
            _as.Pause();
        }

        transform.Rotate(rotation);
        
    }

    public void AudioCheck()
    {
        if (!_as.isPlaying)
        {
            _as.Play();
        }
    }
}
