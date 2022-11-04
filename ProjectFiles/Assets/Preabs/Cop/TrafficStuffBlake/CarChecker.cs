using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChecker : MonoBehaviour
{
    public GameObject thisCar;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "car")
        {
            thisCar.GetComponent<followRail>().speed = other.GetComponent<followRail>().speed;
        }
    }

}
