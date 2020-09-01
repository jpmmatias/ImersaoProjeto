using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public static MovingCube CurrentCube { get;private set;}
    public static MovingCube LastCube { get; private set; }
    private float hangover;

    private void OnEnable()
    {
        if(LastCube == null)
        {
            LastCube = GameObject.Find("startCube").GetComponent<MovingCube>();
        }

        CurrentCube = this;
        GetComponent<Renderer>().material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        hangover = transform.position.z - LastCube.transform.position.z;
        if (hangover > .8f)
        {
            moveSpeed = moveSpeed * -1;
        }
        if (hangover <-.8f)
        {
            moveSpeed = moveSpeed * -1;
        }
    }

    public void Stop()
    {
        moveSpeed = 0;
        Debug.Log(hangover);
        if (hangover > -0.01f && hangover < 0.01f)
        {
            transform.position = new Vector3 (transform.position.x,transform.position.y, LastCube.transform.position.z);

        }
    }
}
