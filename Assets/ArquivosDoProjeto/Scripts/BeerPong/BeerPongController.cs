using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongController : MonoBehaviour
{
    public GameObject targetPrefab;
    public SceneLoader sceneLoader;
    public int targetAmount;
    public PlayBeerPong player;
    private bool boolGameWin;
    public int availableShots = 10;
    public int NumOfLoses;
    public PlayerMovment playerMovment;

    private bool Onetime = false;

    public Transform table;
    public Vector3[] locations;

    void Start()
    {
        NumOfLoses = PlayerPrefs.GetInt("NumOfLoses", 0);
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
            if (remainingTargets == 1)
            {
                boolGameWin = true;
                StartCoroutine(GameOver());
               
            }
            else
            {
                boolGameWin = false;
                if (!Onetime)
                {
                    NumOfLoses++;
                    PlayerPrefs.SetInt("NumOfLoses", NumOfLoses);
                    Onetime = true;
                }
                StartCoroutine(GameOver());
            }
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
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetInt("win" + 0, boolToInt(boolGameWin));
        sceneLoader.LoadCasaScene();
    }
}

