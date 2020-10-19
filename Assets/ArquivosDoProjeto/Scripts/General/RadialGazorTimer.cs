using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialGazorTimer : MonoBehaviour
{
    public float tempo = 0.0f;
    private bool hover = false;
    public GameObject todo;
    public Transform RadialProgress;


    public void Watching()
    {
        hover = true;
    }

    public void notWatching()
    {
        tempo = 0f;
        RadialProgress.GetComponent<Image>().fillAmount = tempo;
        hover = false;
      
    }

    public void Update()
    {
        if (hover)
        {
            tempo += Time.deltaTime;
            RadialProgress.GetComponent<Image>().fillAmount = tempo / 2f;
            if (tempo >= 2f)
            {
                todo.SetActive(true);
            }
        }
    }
}
