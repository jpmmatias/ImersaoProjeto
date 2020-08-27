using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public GameObject DialoguePanel;
    public PlayerMovment playerMovment;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DialoguePanel.SetActive(true);
            playerMovment.stop = true;
        }
    }
}
