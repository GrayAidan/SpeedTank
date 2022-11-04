using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextRoad : MonoBehaviour
{
    public GameObject nextR;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "road")
        {
            nextR = other.gameObject;
        }
    }

}
