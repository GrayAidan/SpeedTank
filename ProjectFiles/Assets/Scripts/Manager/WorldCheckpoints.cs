using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCheckpoints : MonoBehaviour
{
    public NewWorldGen nwg;
    public GameObject half;
    public GameObject full;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(half);

            nwg.Spawn();
            nwg.prevFull = full;
        }
        

    }
}
