using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongController : MonoBehaviour
{
    public GameObject targetPrefab;
    public int targetAmount;
    public PlayBeerPong player;
    public int availableShots = 10;
    public PlayerMovment playerMovment;

    public Transform table;
    public Vector3[] locations;

    void Start()
    {
        playerMovment.stop = true;

        for (int i=0; i < targetAmount; i++)
        {
            GameObject target = Instantiate(targetPrefab);
            target.transform.SetParent(table);
            target.transform.localPosition = locations[i];

        }
        
    }

    void Update()
    {
        int remainingShots = availableShots - player.ballsFired;
        int remainingTargets = table.transform.childCount;
        Debug.Log("remainingShots:"+ remainingShots);
        Debug.Log("remainingTargets:" + remainingTargets);
        if (remainingShots <= 0 || remainingTargets<=0)
        {
            player.haveBalls = false;
            playerMovment.stop = false;
            if (remainingTargets == 0)
            {

                Debug.Log("You Won!");
                Debug.Log("Game Over");
                playerMovment.stop = false;
            }
            else
            {
                Debug.Log("You Lose!");
                Debug.Log("Game Over");
                playerMovment.stop = false;
            }
        }
    }
}
