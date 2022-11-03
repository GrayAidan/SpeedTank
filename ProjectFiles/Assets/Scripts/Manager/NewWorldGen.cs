using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWorldGen : MonoBehaviour
{
    public List<GameObject> Roads;

    public GameObject worldCheckpointPrefab;

    private GameObject currentRoad;
    private GameObject prevRoad;

    [HideInInspector]
    public GameObject prevFull;
    [HideInInspector]
    public GameObject quarter;
    [HideInInspector]
    public GameObject half;
    [HideInInspector]
    public GameObject three;
    [HideInInspector]
    public GameObject full;

    private GameObject lastRoad;

    // Start is called before the first frame update
    void Start()
    {
        currentRoad = Instantiate(Roads[0], transform);
        prevRoad = currentRoad;
        currentRoad = Instantiate(Roads[0], prevRoad.transform.Find("SpawnPoint"));
        currentRoad.transform.SetParent(transform);
        Spawn();
    }

    public void Spawn()
    {
        GameObject half = new GameObject("half");
        GameObject full = new GameObject("full");

        half.transform.SetParent(transform);
        full.transform.SetParent(transform);

        if(prevFull != null)
        {
            Destroy(prevFull);
        }

        for (int i = 0; i < 20; i++)
        {
            if(lastRoad == null)
            {
                prevRoad = currentRoad;
            }
            else
            {
                prevRoad = lastRoad;
            }

            currentRoad = Instantiate(Roads[Random.Range(0, Roads.Count)], prevRoad.transform.Find("SpawnPoint"));

            if (i < 5)
            {
                currentRoad.transform.SetParent(half.transform);
                
            }
            else if (i == 10)
            {
                GameObject currentWCP = Instantiate(worldCheckpointPrefab, currentRoad.transform);
                currentWCP.GetComponent<WorldCheckpoints>().nwg = this;
                currentWCP.GetComponent<WorldCheckpoints>().half = half;
                currentWCP.GetComponent<WorldCheckpoints>().full = full;
            }
            else if (i < 20)
            {
                currentRoad.transform.SetParent(full.transform);
            }
            else if(i == 20)
            {
                lastRoad = currentRoad;
            }
        }
    }
}
