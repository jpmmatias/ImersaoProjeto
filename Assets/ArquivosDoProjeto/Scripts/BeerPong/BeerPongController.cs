﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongController : MonoBehaviour
{
    public GameObject targetPrefab;
    public int targetAmount;
    public PlayBeerPong player;
    public int availableShots = 10;
    public float targetDistanceMin = 2f;
    public float targetDistanceMax = 5f;
    public PlayerMovment playerMovment;

    void Start()
    {
        playerMovment.stop = true;
        for(int i=0; i < targetAmount; i++)
        {
            GameObject target = Instantiate(targetPrefab);
            target.transform.SetParent(transform);
            target.transform.position = new Vector3(Random.Range(targetDistanceMin, targetDistanceMax), 3, Random.Range(targetDistanceMin, targetDistanceMax));

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        int remainingShots = availableShots - player.ballsFired;
        int remainingTargets = transform.childCount;
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
            }
            else
            {
                Debug.Log("You Lose!");
                Debug.Log("Game Over");
            }
        }
    }
}