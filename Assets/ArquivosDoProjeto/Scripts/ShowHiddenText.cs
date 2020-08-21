using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHiddenText : MonoBehaviour
{
    public GameObject InfoObject;
    private bool ShowT= false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHidenInfo()
    {
        if (!ShowT)
        {
            InfoObject.SetActive(true);
            ShowT = true;
        }
        else
        {
            InfoObject.SetActive(false);
            ShowT = false;
        }
    }
}
