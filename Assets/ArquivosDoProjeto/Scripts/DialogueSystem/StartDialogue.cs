using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public GameObject DialoguePanel;
    public GameObject DialoguePanelWin;
    public int i;
    public PlayerMovment playerMovment;
    private void Update()
    {
        if (intToBool(PlayerPrefs.GetInt("win" + i, 0)))
        {

        }
        
    }

    private int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    private bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && intToBool(PlayerPrefs.GetInt("win" + i, 0)) == false)
        {
            DialoguePanel.SetActive(true);
            playerMovment.stop = true;
        }

        if (collision.gameObject.tag == "Player" && intToBool(PlayerPrefs.GetInt("win" + i, 0)) == true)
        {
            playerMovment.stop = true;
            Destroy(DialoguePanel);
            DialoguePanelWin.SetActive(true);
            
        }
    }
}
