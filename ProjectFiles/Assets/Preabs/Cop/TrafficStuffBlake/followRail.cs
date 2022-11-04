using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class followRail : MonoBehaviour
{

    public PathCreator railCreator;
    public GameObject tank;

    //TANK VAR
    Vector3 tankPos;
    Vector3 direction;
    public bool lost = false;

    //CREATION VARIABLES
    GameObject copSpawnDetector;//for cop spawn rails
    public PathCreator[] spawnPoints; //store the spawn rails
    public int randomSpawn; //random rail
    //RoadGeneration roadScript;

    //MOVEMENT VARIABLES
    public float speed; 
    float distanceTravelled;
    float randomSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float rotationSpeed;

    //CONTINIOUS VARIABLES
    public GameObject currentRail; //current road tank is on
    public GameObject nextRail; //next rail
    public GameObject detector; //next road from detector
    bool started = false;
    bool firstRail = false;

    //RAIL VARIABLES
    GameObject railParent;

    void Start()
    {
        copSpawnDetector = GameObject.Find("copSpawn"); //world generate object so it can always grab the police and car spawns.

        randomSpeed = Random.Range(minSpeed,maxSpeed);
    }


    void Update()
    {
        if (started == false)
        {
            RoadCheck roadScript = copSpawnDetector.GetComponent<RoadCheck>(); //grab the road the object is on
            if (firstRail == false)
            {
                currentRail = roadScript.road;
                firstRail = true;
            }
            nextRail = detector.GetComponent<nextRoad>().nextR;
            speed = randomSpeed;
            started = true;
        }

        railParent = currentRail.transform.parent.gameObject;


        SpawnArray spawnArrays = railParent.GetComponentInChildren<SpawnArray>(); //grabs rail array from prefab
        spawnPoints = spawnArrays.railArray;
        railCreator = spawnPoints[randomSpawn];

        distanceTravelled += speed * Time.deltaTime;
        if (lost == false)
        {
            transform.position = railCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = railCreator.path.GetRotationAtDistance(distanceTravelled);
        }

        if (distanceTravelled >= railCreator.path.length && lost == false)
        {
            Debug.Log("COP PASSED");
            nextRail = detector.GetComponent<nextRoad>().nextR;
            currentRail = nextRail;
            distanceTravelled = 0f;
            started = false;
        }

        tank = GameObject.FindGameObjectWithTag("tank");
        tankPos = tank.transform.position;
        direction = tankPos - transform.position; //get direction
        direction.Normalize();

        Debug.DrawLine(transform.position,transform.forward,Color.magenta);
        if (lost == true) //once past tank check which side the tank is on
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (Vector3.Dot(transform.forward, direction) > 0.1)
            {
                transform.Rotate(new Vector3(Time.deltaTime * rotationSpeed,0,0));
            }
            else if (Vector3.Dot(transform.right, direction) < -0.1)
            {
                transform.Rotate(new Vector3(Time.deltaTime * -rotationSpeed, 0, 0));
            }
        }

        if (currentRail == null) Destroy(gameObject);

    }


}
