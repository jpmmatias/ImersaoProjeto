using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Iventory iventory;
    public int numberOfTheItem;
    private bool isTaken;
    public GameObject itemButton;

    public GameObject PlayerCamera;
    public bool taken = false;
    private void Awake()
    {
        iventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Iventory>();

    }
    void Start()
    {
        isTaken = intToBool(PlayerPrefs.GetInt("Item"+ numberOfTheItem, 0));
        if (isTaken)
        {
           
            Destroy(gameObject);
        }

    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "key")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    taken = !taken;
                    for (int i = 0; i < iventory.slots.Length; i++)
                    {
                        if (iventory.isFull[i] == false)
                        {
                            iventory.isFull[i] = true;
                            Instantiate(itemButton, iventory.slots[i].transform, false);
                            isTaken = true;
                            Destroy(this.gameObject);
                            break;
                        }
                    }
                }
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


    private void OnDestroy()
    {

        PlayerPrefs.SetInt("Item" + numberOfTheItem, boolToInt(isTaken));
        

    }
}
