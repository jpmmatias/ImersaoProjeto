using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMenu : MonoBehaviour
{
    public GameObject CircleMenuPanel;
    public PlayerMovment playerMovment;
    public GameObject iventoryCanvas;
    private bool Stop;
    private void Start()
    {
        Stop = false; 
    }
    public void ShowHidenMenu()
    {
        Stop = !Stop;
        playerMovment.stop = Stop;
        if (CircleMenuPanel != null)
        {
            iventoryCanvas.SetActive(false);
            Animator animator = CircleMenuPanel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }


}
