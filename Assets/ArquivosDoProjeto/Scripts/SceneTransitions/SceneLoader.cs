using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float trasitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadStartMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadCasaScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadMenuGameOverCasaScene()
    {
        PlayerPrefs.SetInt("NumOfLoses", 0);
        StartCoroutine(LoadLevel(1));
    }

    public void LoadCupAndBall()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void LoadBeerPong()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void LoadWhackMole()
    {
        StartCoroutine(LoadLevel(4));
    }

    public void GameOverMenu()
    {
        StartCoroutine(LoadLevel(5));
    }

    public void WinGameOverMenu()
    {
        StartCoroutine(LoadLevel(6));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(trasitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
