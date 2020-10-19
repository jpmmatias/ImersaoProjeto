using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copo : MonoBehaviour
{
    public Rigidbody rb;
    private Vector2 startSwipe;
    private Vector2 endS;
    public float force = 100f;
    public float torque = 15f;
    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1") && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
           
            startSwipe = Camera.main.ScreenToViewportPoint(transform.forward);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            endS= Camera.main.ScreenToViewportPoint(transform.forward);
            Swipe();
        }
    }

 private void Swipe()
    {
        Vector2 swipe = startSwipe - endS ;
        rb.AddForce(swipe *force, ForceMode.Impulse);
        rb.AddTorque(0f, 0f, torque, ForceMode.Impulse);
    }
}
