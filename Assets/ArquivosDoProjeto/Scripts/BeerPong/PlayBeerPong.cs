using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBeerPong : MonoBehaviour
{
    public float force = 400f;
    public GameObject ballPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.position = transform.position;
            ball.GetComponent<Rigidbody>().AddForce(transform.forward *force);

        } 
    }
}
