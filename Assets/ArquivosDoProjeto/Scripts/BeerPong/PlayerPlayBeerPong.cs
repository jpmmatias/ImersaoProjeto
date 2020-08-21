using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayBeerPong : MonoBehaviour
{
    public GameObject ball;
    public Vector3 ballOffset;
    public float ballDistance = 1f;
    public float maxForce=1000f;
    public float minForce = 400f;
    private bool holding;
    public float shootingTimer=0f;
    private bool calculatingShot=false;
    public PlayerMovment playerMovment;
    void Start()
    {
        holding = true;
        
    }

    
    void Update()
    {
        if (holding)
        {

            ball.transform.position = transform.position + transform.forward * ballDistance + ballOffset;
            ball.GetComponent<Rigidbody>().useGravity = false;
            playerMovment.stop = true;

            if (calculatingShot)
            {
                shootingTimer += Time.deltaTime;
                if (shootingTimer > 5f)
                {
                    shootingTimer = 0f;
                }
               
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if (calculatingShot==false)
                {
                    calculatingShot = true ;
                }
                else if (holding)
                {
                    holding = false;
                    ball.GetComponent<Rigidbody>().useGravity = true;
                    float calculatedScale = Mathf.Min(shootingTimer, 5f);
                    float force = minForce + (maxForce - minForce)*calculatedScale;
                    ball.GetComponent<Rigidbody>().AddForce(transform.forward * force);
                    playerMovment.stop = false;
                }
            }
        }
       
    }
}
