using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSmoke : MonoBehaviour
{
    public float destroyTime;
    public AudioSource _as;

    // Start is called before the first frame update
    void Start()
    {
        _as.Play();
        StartCoroutine(TimedVisualDestroy());
        StartCoroutine(TimedDestroy());
    }

    public IEnumerator TimedVisualDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<MeshRenderer>().enabled = false;
    }

    public IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
