using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSmoke : MonoBehaviour
{
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimedDestroy());
    }

    public IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
