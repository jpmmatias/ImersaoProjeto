using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPlayCupBall : MonoBehaviour
{
    public bool canPick = false;
    public bool picked = false;
    public bool won = false;
    public PlayerMovment playerMovment;


    void Start()
    {
        
    }

    void Update()
    {
        if (canPick == true)
        {
            if (Input.GetButtonDown("Fire1")){
                RaycastHit hit;

                if (Physics.Raycast(transform.position,transform.forward,out hit))
                {
                    Cup cup = hit.transform.GetComponent<Cup>();
                    if(cup != null)
                    {
                        canPick = false;
                        picked = true;
                        won = (cup.ball != null);
                        cup.MoveUp();
                        playerMovment.stop = false;
                    }
                }
            }
                
        }
    }
}
