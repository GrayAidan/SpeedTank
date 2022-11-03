using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopExplosion : MonoBehaviour
{
    public AudioSource _as;

    public float destructionTime;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.Find("GeneratedWorld").transform);
        _as.Play();
        StartCoroutine(TimedDestruction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TimedDestruction()
    {
        yield return new WaitForSeconds(destructionTime);
        Destroy(this.gameObject);
    }
}
