using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceStaticSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Static.deaths = 0;
        Static.distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Static.distance = (int) transform.position.z * -1;
    }
}
