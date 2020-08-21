using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GazeInteraction : MonoBehaviour
{

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public Transform RadialProgress;

    void Update()
    {

        if (gazedAt)
        {
            timer += Time.deltaTime;
            RadialProgress.GetComponent<Image>().fillAmount = timer / 2;

            if (timer >= gazeTime)
            {
                RadialProgress.GetComponent<Image>().fillAmount = 0;
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
               

            }
        }

    }

    public void PointerEnter()
    {
        gazedAt = true;
        Debug.Log("PointerEnter");
    }

    public void PointerExit()
    {
        gazedAt = false;
        Debug.Log("PointerExit");
        RadialProgress.GetComponent<Image>().fillAmount = 0;
    }

    public void PointerDown()
    {
        Debug.Log("PointerDown");
        RadialProgress.GetComponent<Image>().fillAmount = 0;
    }
}
