using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopBehaviour : MonoBehaviour
{
    public Vector3 tankPos; //in case we end up changing the tanks position it will be easier to make changes to the transform behaviour

    public Vector3 direction;
    public float speed;
    public float rotationSpeed;


    GameObject generateWorld;
    float worldSpeed;
    float overallSpeed;

    private void Start()
    {
        generateWorld = GameObject.Find("GeneratedWorld"); //world generate object so it can always grab the world speed.
    }

    void Update()
    {
        WorldMovement movementScript = generateWorld.GetComponent<WorldMovement>(); //keeps spawns as children of road while also staying behind tank
        worldSpeed = movementScript.moveSpeed;

        overallSpeed = worldSpeed + speed;

        direction = tankPos - transform.position; //get direction
        direction.Normalize();

        Debug.Log(overallSpeed);

        //transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(-10.5f, tankPos.z, overallSpeed) * Time.deltaTime);

        //transform.Translate(0,0,overallSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * (overallSpeed +10f) * Time.deltaTime); //always stay moving forward (needs to be worked on so cops rotate with world) 

        if (transform.position.z > tankPos.z - 1.5) //once past tank check which side the tank is on
        {
            if (Vector3.Dot(transform.right, direction) > 0.1)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            }
            else if (Vector3.Dot(transform.right, direction) < -0.1)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            }
        }
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {



    }
}
