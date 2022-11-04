using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TrafficFollowRail : MonoBehaviour
{
    public PathCreator railCreator;

    //CREATION VARIABLES
    public GameObject roadDetector;//for cop spawn rails
    public PathCreator[] spawnPoints; //store the spawn rails
    public int randomSpawn; //random rail
    public float selfDestructTimer;
    //RoadGeneration roadScript;

    //MOVEMENT VARIABLES
    public float speed;
    public float distanceTravelled;
    float randomSpeed;
    public float maxSpeed;
    public float minSpeed;

    //CONTINIOUS VARIABLES
    public GameObject currentRail; //current road tank is on
    public GameObject nextRail; //next rail
    public GameObject detector; //next road from detector
    bool started = false;
    bool firstRail = false;

    //RAIL VARIABLES
    GameObject spawnRailParent;
    GameObject railParent;
    GameObject nextRailParent;
    SpawnArray spawnArrays;

    void Start()
    {
        roadDetector = GameObject.Find("TrafficSpawn"); //world generate object so it can always grab the police and car spawns.

        randomSpeed = Random.Range(minSpeed, maxSpeed);
    }


    void Update()
    {
        if (started == false)
        {
            RoadCheck roadScript = roadDetector.GetComponent<RoadCheck>(); //grab the road the object is on
            if (firstRail == false)
            {
                currentRail = roadScript.road;
                spawnRailParent = currentRail.transform.parent.gameObject;
                spawnArrays = spawnRailParent.GetComponentInChildren<SpawnArray>(); //grabs rail array from prefab
                spawnPoints = spawnArrays.railArray;
                railCreator = spawnPoints[randomSpawn];
                firstRail = true;
            }
            speed = randomSpeed;
            started = true;
        }

        selfDestructTimer -= Time.deltaTime;

        distanceTravelled += speed * Time.deltaTime;
        if (distanceTravelled < railCreator.path.length)
        {
            transform.position = railCreator.path.GetPointAtDistance(-distanceTravelled);
            transform.rotation = railCreator.path.GetRotationAtDistance(-distanceTravelled);
        }

        if (distanceTravelled >= railCreator.path.length)
        {
            nextRail = detector.GetComponent<nextRoad>().nextR;
            nextRailParent = nextRail.transform.parent.gameObject;
            spawnArrays = nextRailParent.GetComponentInChildren<SpawnArray>();
            spawnPoints = spawnArrays.railArray;
            railCreator = spawnPoints[randomSpawn];

            distanceTravelled = 0f;
            started = false;
        }

        if (selfDestructTimer <= 0)
        {
            Object.Destroy(gameObject);
        }

        // if (currentRail == null) Destroy(gameObject);
    }

}
