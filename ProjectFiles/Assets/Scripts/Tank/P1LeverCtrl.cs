using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1LeverCtrl : MonoBehaviour
{
    private Vector3 rotation; //the rotation that is used to move the camera

    public float rotataionSpeed;

    public Transform playerTank;

    public Lever1 l1;
    public Lever2 l2;

    public bool playable = false;

    private void Start()
    {
        StartCoroutine(StartPlayable());
    }

    // Update is called once per frame
    void Update()
    {
        if (playable)
        {
            float binary = l1.angle - -(l2.angle * 1 - 1);

            print(binary + " " + l1.angle + " " + l2.angle);

            rotation = new Vector3(0, -binary * rotataionSpeed, 0) * Time.deltaTime;
            transform.position = new Vector3(playerTank.position.x, transform.position.y, playerTank.position.z);

            transform.Rotate(rotation);
        }
        
        

    }

    public IEnumerator StartPlayable()
    {
        yield return new WaitForSeconds(5f);
        playable = true;
    }
}
