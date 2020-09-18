using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class GeneralGameController : MonoBehaviour
{
    public bool[] wins;
    public GameObject[] items;
    public SceneLoader sceneLoader;
    public int NumOfLoses;
    public PlayerMovment playerMove;
    public ParticleSystem vomit;
    public EndGameController endGame;
    void Start()
    {
        for (int i = 0; i < wins.Length; i++)
        {
            wins[i] = intToBool(PlayerPrefs.GetInt("win" + i, 0));

        }

        NumOfLoses = PlayerPrefs.GetInt("NumOfLoses", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (endGame.WinGame)
        {
            StartCoroutine(LoadWin());
        }
        if (wins[0] == true && items[0])
        {
            items[0].SetActive(true);
        }
        if (wins[1] == true && items[1])
        {
            items[1].SetActive(true);
        }

        if (wins[2] == true && items[2])
        {
            items[2].SetActive(true);
        }

        if (NumOfLoses > 3)
        {
            playerMove.stop = true;
            vomit.Emit(200);
            StartCoroutine(LoadGameOverMenu());
           
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

    private void OnDestroy()
    {
        for (int i = 0; i < wins.Length; i++)
        {
            PlayerPrefs.SetInt("win" + i, boolToInt(wins[i]));
        }

        PlayerPrefs.SetInt("NumOfLoses", NumOfLoses);

    }

    IEnumerator LoadGameOverMenu()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < wins.Length; i++)
        {
            wins[i] = false;
        }

        PlayerPrefs.DeleteAll();
        sceneLoader.GameOverMenu();
    }

    IEnumerator LoadWin()
    {
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < wins.Length; i++)
        {
            wins[i] = false;
        }
        PlayerPrefs.DeleteAll();
        sceneLoader.WinGameOverMenu();
    }
}
