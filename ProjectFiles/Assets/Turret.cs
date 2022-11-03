using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject g;
    Crank cScript;
    Quaternion angle;
    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.Find("Crank");
        cScript = g.GetComponent<Crank>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion oldAngle = angle;
        angle = Quaternion.Euler(transform.rotation.x, cScript.rotation, transform.rotation.z); ;
        float deltaAngle = Quaternion.Angle(angle, oldAngle);

        if (Quaternion.Angle(angle, oldAngle * Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z)) < 90)
        {
            rotation += deltaAngle / 5f;
        }
        else 
        {
            rotation -= deltaAngle / 5f;
        }

        if (Time.frameCount < 20) {
            rotation = 0;
        }

        transform.rotation = Quaternion.Euler(-90, rotation, transform.rotation.z);


    }
}
