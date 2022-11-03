using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public RoadGeneration roadGen;
    public Transform distanceFromStart;

    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1 * moveSpeed), Space.World);
        distanceFromStart.Translate(new Vector3(0, 0, -1 * moveSpeed), Space.World);

    }
}
