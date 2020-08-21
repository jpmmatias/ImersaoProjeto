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
        if (Input.GetButtonDown("Fire1"))
        {
     //   startSwipe = Input.mousePosition;

      startSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetButtonUp("Fire1"))
        {
    //  endS  = Input.mousePosition;
    endS= Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Swipe();
        }
    }

 private void Swipe()
    {
        Vector2 swipe = endS - startSwipe;
        rb.AddForce(swipe *force, ForceMode.Impulse);
        rb.AddTorque(0f, 0f, torque, ForceMode.Impulse);
    }
}
