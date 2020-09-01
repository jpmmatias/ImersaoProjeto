using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostJengaGameManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MovingCube.CurrentCube.Stop();
            MovingCube.CurrentCube.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        
    }
}
