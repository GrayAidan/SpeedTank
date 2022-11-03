using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObsticalCheck : MonoBehaviour
{
    public GameObject rotation;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject worldMove;
    public GameObject tank;
    public GameObject explosionPrefab;
    public Transform explosionPoint;
    
    private void Start()
    {
        //Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            worldMove.GetComponent<WorldMovement>().enabled = false;
            rotation.GetComponent<P1LeverCtrl>().enabled = false;
            GameObject bruh = Instantiate(explosionPrefab, explosionPoint);
            bruh.transform.SetParent(null);
            cam1.transform.SetParent(null);
            cam2.transform.SetParent(null);            
            Invoke("LoadSceneTHing", 0.5f);
            //Destroy(tank);
        }
    }

    public void LoadSceneTHing()
    {
        SceneManager.LoadScene("gameover");
        print("bruh");
    }
}
