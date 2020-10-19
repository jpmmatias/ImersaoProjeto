using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerCasa : MonoBehaviour
{
    public TesteKey testeKey;
    public Door door;
    public TextMesh playerStats;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (testeKey.taken)
        {
            door.CanOpen = true;
        }

        
    }
}
