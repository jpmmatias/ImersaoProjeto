using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpawner : MonoBehaviour
{
    public movingBlock blockPrefab;
   
    public void SpawnBlock()
    {
        var block = Instantiate(blockPrefab);
        if (movingBlock.LastBlock != null && movingBlock.LastBlock.gameObject != GameObject.Find("Start"))
        {
            block.transform.position = new Vector3(transform.position.x,
                movingBlock.LastBlock.transform.position.y + blockPrefab.transform.localScale.y,
                transform.position.z);
        }
        else
        {
            block.transform.position = transform.position;
        }
    }
}
