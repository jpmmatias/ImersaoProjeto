using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteKey : MonoBehaviour
{
    public GameObject PlayerCamera;
    public bool taken = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward,out hit))
        {
            if (hit.transform.tag == "key")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    taken = !taken;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
