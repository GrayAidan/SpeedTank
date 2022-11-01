using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public RoadGeneration roadGen;
    public Transform distanceFromStart;

    public float moveSpeed;

    private bool generatable;
    private int section;

    private int counter;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,-1 * moveSpeed), Space.World);
        distanceFromStart.Translate(new Vector3(0, 0, -1 * moveSpeed), Space.World);

        if (section == 0)
        {
            FirstCheck();
        }
        else if (section == 1)
        {
            SecondCheck();
        }
        else
        {
            Check();
        }
    }

    public void Check()
    {
        if ((int)Mathf.Abs(distanceFromStart.position.z) % 50 == 0 && generatable)
        {
            CanSpawnCounter();
            generatable = false;
        }
        else if ((int)Mathf.Abs(distanceFromStart.position.z) % 50 != 0)
        {
            generatable = true;
        }
    }

    public void SecondCheck()
    {
        if ((int)Mathf.Abs(distanceFromStart.position.z) == 250)
        {
            roadGen.SpawnNewRoad();
            section++;
        }
    }

    public void FirstCheck()
    {
        if ((int) Mathf.Abs(distanceFromStart.position.z) == 150)
        {
            roadGen.SpawnNewRoad();
            section++;
        }
    }

    public void CanSpawnCounter()
    {
        if(counter < 2)
        {
            counter++;
        }
        if(counter == 2)
        {
            roadGen.SpawnNewRoad();
            counter = 0;
        }
    }
}
