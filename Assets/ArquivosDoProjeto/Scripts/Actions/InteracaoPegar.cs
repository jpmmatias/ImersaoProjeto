using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InteracaoPegar : MonoBehaviour
{
    private Camera CameraVR;
    private Transform TransformOriginal;
    private void Start()
    {
        CameraVR = Camera.main;
        TransformOriginal = gameObject.transform.parent;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.M))//usei o M pq não é atalho para nada
        {
            gameObject.transform.parent = CameraVR.transform;
        }
        else
        {
            gameObject.transform.parent = TransformOriginal;
        }
    }
}
