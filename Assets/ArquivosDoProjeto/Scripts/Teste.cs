using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teste : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public GameObject cubo;


    public void Start()
    {
        print("oi");
    cubo.GetComponent<Renderer>().material = material2;
    }
}
