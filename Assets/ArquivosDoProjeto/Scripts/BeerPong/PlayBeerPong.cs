using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBeerPong : MonoBehaviour
{
    public float force = 400f;
    public GameObject ballPrefab;
    public int ballsFired=0;
    public bool haveBalls = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && haveBalls)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.position = transform.position;
            ball.GetComponent<Rigidbody>().AddForce(transform.forward *force);
            ballsFired++;

        } 
    }
}
