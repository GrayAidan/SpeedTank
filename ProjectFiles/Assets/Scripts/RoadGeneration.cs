using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGeneration : MonoBehaviour
{

    public List<GameObject> Roads;
    
    // Start is called before the first frame update
    void Start()
    {
        StartGeneration();
    }

    public void StartGeneration()
    {
        Instantiate(Roads[Random.Range(0, Roads.Count)], transform);
    }
}
