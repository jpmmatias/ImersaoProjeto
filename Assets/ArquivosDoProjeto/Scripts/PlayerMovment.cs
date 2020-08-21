using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int playerSpeed;
    private CharacterController controller;
    private float gravity = 10f;
  
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

   
    void Update()
    {
        //Touch

        if (Input.GetButton("Fire1"))
        {
            transform.position = new Vector3(transform.position.x + Camera.main.transform.forward.x * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z + Camera.main.transform.forward.z * playerSpeed * Time.deltaTime);
        }

        //Controle
        //PlayerWalk();


    }

    private void PlayerWalk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * playerSpeed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);



    }
}
