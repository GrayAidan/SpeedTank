using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopDestruction : MonoBehaviour
{
    public GameObject copExplosin;

    private GameObject currentCopExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            currentCopExplosion = Instantiate(copExplosin, this.transform);
            currentCopExplosion.transform.SetParent(null);
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
        
        
    }
}
