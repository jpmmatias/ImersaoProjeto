using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBeerPong : MonoBehaviour
{
    public bool hitSomething;
    public bool gotRightTarget;
    public int score = 0;
   
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "targetBeerPong")
        {
            hitSomething = true;
            gotRightTarget = true;
            score ++;
        } else if (other.tag== "wrongTargetBeerPong")
        {
            hitSomething = true;
            gotRightTarget = false;
        }
    }
}
