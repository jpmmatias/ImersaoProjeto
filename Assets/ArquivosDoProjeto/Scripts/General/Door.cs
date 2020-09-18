using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool CanOpen = false;
    public int numberOfTheItem;
    public int numberOfTheItem2;
    private bool isTaken;
    private bool isTaken2;
    private bool opened = false;
    private Animator anim;

    private void Start()
    {
       

    }

    void Update()
    {
        isTaken = intToBool(PlayerPrefs.GetInt("Item" + numberOfTheItem, 0));
        isTaken2 = intToBool(PlayerPrefs.GetInt("Item" + numberOfTheItem2, 0));
        if (isTaken && isTaken2)
        {
            CanOpen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (CanOpen)

            {
                Pressed();

            }
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

    void Pressed()
    {
        anim = gameObject.GetComponent<Animator>();
        opened = !opened;
        anim.SetBool("Opened", opened);
    }
}