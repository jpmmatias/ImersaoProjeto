using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int playerSpeed;
    private int savedSpeed;
    public bool stop = false;
    private CharacterController controller;
    private float gravity = 10f;
  
    void Start()
    {
        controller = GetComponent<CharacterController>();
        savedSpeed = playerSpeed;

    }

   
    void Update()
    {
        if (stop)
        {
            playerSpeed = 0;
            Debug.Log("stop");
        }
        else
        {
            StartCoroutine(moveAgain());
        }
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

    private IEnumerator moveAgain()
    {
        yield return new WaitForSeconds(.5f);
        playerSpeed = savedSpeed;
        Debug.Log("moving");
}
}
