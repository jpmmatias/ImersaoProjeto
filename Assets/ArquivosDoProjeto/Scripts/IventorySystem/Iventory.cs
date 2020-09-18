using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject[] itemButtons;


    void Start()
    {
        for (int i = 0; i < isFull.Length; i++)
        {
            isFull[i]= intToBool( PlayerPrefs.GetInt("isFull" + i, 0));
            if (isFull[i])
            {
                Instantiate(itemButtons[i], slots[i].transform, false);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnDestroy()
    {
        //for (int i = 0; i < slots.Length; i++)
        //{
        //    PlayerPrefs.SetInt("slots" + i, boolToInt(slots[i]));
        //}
        for (int i = 0; i < isFull.Length; i++)
        {
            PlayerPrefs.SetInt("isFull" + i, boolToInt(isFull[i]));
        }
        
    }
}
