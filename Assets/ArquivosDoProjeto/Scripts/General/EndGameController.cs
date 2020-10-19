using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public bool WinGame = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WinGame = true;
        }
    }
}
