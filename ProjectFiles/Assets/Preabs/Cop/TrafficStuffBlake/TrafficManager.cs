using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    public GameObject cop;

    //SPAWN VARIABLES
    public float timer;
    public float minTimer;
    public float maxTimer;
    public int randomRail;
    public int lastSpawnPos;


    void Start()
    {
        timer = Random.Range(minTimer, maxTimer);
    }

    private void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            randomRail = Random.Range(0, 5);
            if (randomRail != lastSpawnPos)
            {
                spawnCop(randomRail);
                lastSpawnPos = randomRail;
            }
            else
            {
                randomRail = Random.Range(0, 5);
            }

        }
    }


    void spawnCop(int position)
    {
        GameObject copSpawned = Instantiate(cop, transform.position, new Quaternion());
        copSpawned.GetComponent<TrafficFollowRail>().randomSpawn = position;
        timer = Random.Range(minTimer, maxTimer);
    }
}
