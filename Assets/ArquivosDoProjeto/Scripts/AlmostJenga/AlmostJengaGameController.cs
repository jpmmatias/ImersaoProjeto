using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostJengaGameController : MonoBehaviour
{

    private int points = 0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (movingBlock.CurrentBlock != null)
            {
                movingBlock.CurrentBlock.Stop();
            }
            StartCoroutine(spawnDelay());
           
        }

     
    }
    IEnumerator spawnDelay()
    {
        points++;
        yield return new WaitForSeconds(.25f);
        FindObjectOfType<blockSpawner>().SpawnBlock();
    }   
}
