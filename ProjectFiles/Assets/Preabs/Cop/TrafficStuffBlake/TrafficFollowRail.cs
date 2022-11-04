using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TrafficFollowRail : MonoBehaviour
{
    public PathCreator railCreator;

    //CREATION VARIABLES
    GameObject generateWorld;//for cop spawn rails
    public PathCreator[] spawnPoints; //store the spawn rails
    public int randomSpawn; //random rail
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

    public SpawnArray spawnArrays;

    void Start()
    {
        generateWorld = GameObject.Find("GeneratedWorld"); //world generate object so it can always grab the police and car spawns.

        randomSpeed = Random.Range(minSpeed, maxSpeed);
    }


    void Update()
    {
        if (started == false)
        {
            RoadGeneration roadScript = generateWorld.GetComponent<RoadGeneration>(); //grab the road the object is on
            if (firstRail == false)
            {
                currentRail = roadScript.mid1Road;
                firstRail = true;
            }
            nextRail = detector.GetComponent<trafficroadcheck>().nextR;
            speed = randomSpeed;
            started = true;
        }
        
        spawnArrays = currentRail.GetComponentInChildren<SpawnArray>(); //grabs rail array from prefab
        spawnPoints = spawnArrays.railArray;
        railCreator = spawnPoints[randomSpawn];

        distanceTravelled += speed * Time.deltaTime;
        transform.position = railCreator.path.GetPointAtDistance(-distanceTravelled);
        transform.rotation = railCreator.path.GetRotationAtDistance(-distanceTravelled);

        if (distanceTravelled >= railCreator.path.length)
        {
            nextRail = detector.GetComponent<trafficroadcheck>().nextR;
            currentRail = nextRail;
            distanceTravelled = 0f;
            started = false;
        }

        // if (currentRail == null) Destroy(gameObject);
    }

}
