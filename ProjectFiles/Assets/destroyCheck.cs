using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCheck : MonoBehaviour
{
    public GameObject road;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
