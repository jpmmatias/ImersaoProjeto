using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBlock : MonoBehaviour
{
    [SerializeField]
    public float speed = 2f;
    public AlmostJengaGameController GameController;
    public static movingBlock CurrentBlock { get; private set; }
    public static movingBlock LastBlock { get; private set; }
    private float hangover;
    private int reverse = 1;
    private void OnEnable()
    {
        if (LastBlock == null)
        {
            LastBlock = GameObject.Find("startBlock").GetComponent<movingBlock>();
        }
        CurrentBlock = this;
        GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

   internal void Stop()
    {
        speed = 0;
        GravityOrNot(hangover);
    }

    private void GravityOrNot(float hangover)
    {
        if(hangover>-0.2f && hangover < 0.15f)
        {
            transform.position = new Vector3(LastBlock.transform.position.x, transform.position.y, LastBlock.transform.position.z);
            LastBlock = this;
        }
        else
        {
            transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
            LastBlock = this;
        }

        Debug.Log(hangover);
        
    }
    void Update()
    {
        transform.position += reverse* transform.forward * Time.deltaTime * speed;
        hangover = transform.position.z - LastBlock.transform.position.z;
        Debug.Log(hangover);
        if (hangover > 3f)
        {
            reverse = -1;
        }
        if (hangover < -3f ){
            reverse = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floorJenga"))
        {
            Debug.Log("GameOver");
        }
    }
}
