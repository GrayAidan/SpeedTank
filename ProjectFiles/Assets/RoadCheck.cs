using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class RoadCheck : MonoBehaviour
{
    public GameObject road;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "road")
        {
            road = other.gameObject;
        }
    }
}
