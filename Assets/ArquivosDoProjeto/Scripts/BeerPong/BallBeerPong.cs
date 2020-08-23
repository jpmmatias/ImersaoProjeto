using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBeerPong : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "targetBeerPong")
        {
            Destroy(collision.gameObject);
        }


    }
}
