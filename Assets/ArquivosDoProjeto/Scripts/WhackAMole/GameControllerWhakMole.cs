using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerWhakMole : MonoBehaviour
{
    public GameObject moleContainer;
    public playerPlayWhackMole player;
    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float minimumSpawnDuration = 0.5f;
    public float gameTimer = 15f;

    private Mole[] moles;
    private float spawnTimer = 0f;
    private float resetTimer = 3f;

    // Use this for initialization
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;

        if (gameTimer > 0f)
        {

            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                moles[Random.Range(0, moles.Length)].Rise();

                spawnDuration -= spawnDecrement;
                if (spawnDuration < minimumSpawnDuration)
                {
                    spawnDuration = minimumSpawnDuration;
                }

                spawnTimer = spawnDuration;
            }
        }
        else
        {
            
            Debug.Log( "Game over! Your score: " + Mathf.Floor(player.score));
            if (Mathf.Floor(player.score) > 5)
            {
                Debug.Log("You Win");
            }
            else
            {
                Debug.Log("You lose");
            }
            resetTimer -= Time.deltaTime;
           
        }
    }
}
