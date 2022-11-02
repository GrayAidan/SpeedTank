using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody _rb;
    public float bulletSpeed;

    public float destroyTime;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Vector3 speed = new Vector3(0, 1 * bulletSpeed, 0);
        _rb.AddRelativeForce(speed, ForceMode.VelocityChange) ;
        print(_rb.velocity);

        StartCoroutine(TimedDestroy());
    }

    public IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
