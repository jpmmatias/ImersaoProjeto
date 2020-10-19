using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenIventory : MonoBehaviour
{
    public GameObject iventoryCanvas;
    private bool IsOpen;
    private void Start()
    {
        IsOpen = false;
    }
    public void OpenAndCloseIventory()
    {
        iventoryCanvas.SetActive(!IsOpen);
        IsOpen = !IsOpen;
    }

}
