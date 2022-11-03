using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public float distanceScore;
    public float killScore;

    public GameObject distanceText;
    public GameObject killText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceText.GetComponent<TMPro.TextMeshProUGUI>().text = "Distance: " + distanceScore;
        killText.GetComponent<TMPro.TextMeshProUGUI>().text = "Kills: " + killScore;
    }
}
