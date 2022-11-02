using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shotSmoke;

    private GameObject currentBullet;

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            currentBullet = Instantiate(bulletPrefab, this.transform);
            currentBullet.transform.SetParent(null);


            Instantiate(shotSmoke, this.transform);
        }
    }


}
