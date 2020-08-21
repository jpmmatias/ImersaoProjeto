using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongController : MonoBehaviour
{
    public GameObject targetPrefab;
    public int targetAmount;
    public int availableShots = 10;
    public float targetDistanceMin = 2f;
    public float targetDistanceMax = 5f;

    void Start()
    {
        for(int i=0; i < targetAmount; i++)
        {
            GameObject target = Instantiate(targetPrefab);
            target.transform.position = new Vector3(Random.Range(targetDistanceMin, targetDistanceMax), 3, Random.Range(targetDistanceMin, targetDistanceMax));

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
