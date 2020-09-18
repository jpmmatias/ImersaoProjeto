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
    public SceneLoader SceneLoader;
    private bool Onetime = false;
    private Mole[] moles;
    private float spawnTimer = 0f;
    private float resetTimer = 3f;

    public int NumOfLoses;
    

    private bool WhackGameWin;



    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        NumOfLoses = PlayerPrefs.GetInt("NumOfLoses", 0);
    }

 
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
            
            if (Mathf.Floor(player.score) > 5)
            {
                WhackGameWin = true;
                StartCoroutine(loadCasa());
               
            }
            else
            {
                WhackGameWin = false;
                if (!Onetime)
                {
                    NumOfLoses++;
                    Onetime = true;
                    PlayerPrefs.SetInt("NumOfLoses", NumOfLoses);
                }
                StartCoroutine(loadCasa());
            }
            resetTimer -= Time.deltaTime;
           
        }
    }

    private int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    private bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    

    IEnumerator loadCasa()
    {
        yield return  new WaitForSeconds(1.5f);
        PlayerPrefs.SetInt("win" + 2, boolToInt(WhackGameWin));
        SceneLoader.LoadCasaScene();
    }

}
