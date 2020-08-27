using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongController : MonoBehaviour
{
    public GameObject targetPrefab;
    public SceneLoader sceneLoader;
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
        if (remainingShots <= 0 || remainingTargets<=1)
        {
            player.haveBalls = false;
            Debug.Log(remainingTargets);
            if (remainingTargets == 1)
            {

                Debug.Log("You Won!");
                StartCoroutine(GameOver());
               
            }
            else
            {
                Debug.Log("You Lose!");
                StartCoroutine(GameOver());


            }
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        sceneLoader.LoadCasaScene();
    }
}

