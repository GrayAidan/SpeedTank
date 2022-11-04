using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficroadcheck : MonoBehaviour
{
    public GameObject nextR;

    private void OnTriggerStay(Collider other)
    {
        nextR = other.gameObject;
    }
}
