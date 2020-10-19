using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Cup[] cups;
    public PlayerPlayCupBall player;
    public PlayerMovment playerMovment;
    public SceneLoader sceneLoader;
    public int NumOfLoses;
    private bool Onetime = false;

    private bool WinCupAndBall;

    void Start()
    {
        StartCoroutine(ShuffleRoutine());
        NumOfLoses = PlayerPrefs.GetInt("NumOfLoses");
        playerMovment.stop = true;
    }


    void Update()
    {
        if (player.picked)
        {
            if (player.won)
            {
                WinCupAndBall = true;
                StartCoroutine(EndGameRoutine());
            }
            else
            {
                WinCupAndBall = false;
                if (!Onetime)
                {
                    NumOfLoses++;
                    Onetime = true;
                    PlayerPrefs.SetInt("NumOfLoses", NumOfLoses);
                }
                StartCoroutine(EndGameRoutine());
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

    private IEnumerator EndGameRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        if (!WinCupAndBall)
        {
            NumOfLoses++;
        }
        PlayerPrefs.SetInt("win" + 1, boolToInt(WinCupAndBall));
        sceneLoader.LoadCasaScene();
    }

    private IEnumerator ShuffleRoutine()
    {
        yield return new WaitForSeconds(1f);

        foreach (Cup cup in cups)
        {
            cup.MoveUp();
        }

        yield return new WaitForSeconds(.5f);

        Cup targetCup = cups[Random.Range(0, cups.Length)];
        targetCup.ball = ball;
        ball.transform.position = new Vector3(
            targetCup.transform.position.x, ball.transform.position.y, targetCup.transform.position.z
            );

        yield return new WaitForSeconds(.5f);

        foreach (Cup cup in cups)
        {
            cup.MoveDown();
        }

        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < 5; i++)
        {
            Cup cup1 = cups[Random.Range(0, cups.Length)];
            Cup cup2 = cup1;

            while (cup2 == cup1)
            {
                cup2 = cups[Random.Range(0, cups.Length)];
            }

            Vector3 cup1Position = cup1.targetPosition;
            cup1.targetPosition = cup2.targetPosition;
            cup2.targetPosition = cup1Position;

            yield return new WaitForSeconds(0.75f);
        }

        player.canPick = true;
    }
}