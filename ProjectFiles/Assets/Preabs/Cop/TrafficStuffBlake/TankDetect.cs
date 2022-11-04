using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDetect : MonoBehaviour
{
    public GameObject cop;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tank")
        {
            Debug.Log("gotcha!");
            cop.GetComponent<followRail>().lost = true;
        }
    }
}
