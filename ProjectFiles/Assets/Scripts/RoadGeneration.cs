using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGeneration : MonoBehaviour
{

    public List<GameObject> Roads;

    public GameObject previousRoad;
    public GameObject mid2Road;
    public GameObject mid1Road;
    public GameObject currentRoad;
    private GameObject newestSpawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        StartGeneration();
    }

    private void StartGeneration()
    {
        previousRoad = Instantiate(Roads[Random.Range(0, Roads.Count)], transform);
        mid2Road = Instantiate(Roads[Random.Range(0, Roads.Count)], previousRoad.transform.Find("SpawnPoint"));
        mid1Road = Instantiate(Roads[Random.Range(0, Roads.Count)], mid2Road.transform.Find("SpawnPoint"));
        SpawnNewRoad();
    }

    public void SpawnNewRoad()
    {
        if(currentRoad != null)
        {
            Destroy(previousRoad);
            newestSpawnpoint = currentRoad;
            previousRoad = mid2Road;
            mid2Road = mid1Road;
            mid1Road = currentRoad;
            currentRoad = Instantiate(Roads[Random.Range(0, Roads.Count)], newestSpawnpoint.transform.Find("SpawnPoint"));
            currentRoad.transform.SetParent(this.transform);
        }
        else if (currentRoad == null)
        {
            currentRoad = Instantiate(Roads[Random.Range(0, Roads.Count)], mid1Road.transform.Find("SpawnPoint"));
            previousRoad.transform.SetParent(this.transform);
            mid2Road.transform.SetParent(this.transform);
            mid1Road.transform.SetParent(this.transform);
            currentRoad.transform.SetParent(this.transform);
        }
    }
}
