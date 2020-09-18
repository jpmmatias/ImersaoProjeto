using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
   public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public PlayerMovment playerMovment;
    public GameObject DialoguePanel;
    public SceneLoader sceneLoader;
    public int loadScene;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index] && continueButton)
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            playerMovment.stop = false;
            DialoguePanel.SetActive(false);
            if (loadScene == 3)
            {
                sceneLoader.LoadBeerPong();
            }
            if (loadScene == 2)
            {
                sceneLoader.LoadCupAndBall();
            }
            if (loadScene == 4)
            {
                sceneLoader.LoadWhackMole();
            }
            
}
    }

  
}
