using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public float downHeight = 0.977f;
    public float upHeight = 1.19f;
    public float movingSpeed=1f;
    public GameObject ball;

    public Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
        
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime *movingSpeed);

        if(ball != null)
        {
            ball.transform.position = new Vector3(
                transform.position.x,
                ball.transform.position.y,
                transform.position.z
                );
        }
    }

    public void MoveUp()
    {
        targetPosition = new Vector3(transform.position.x, upHeight, transform.position.z);
    }

    public void MoveDown()
    {
        targetPosition = new Vector3(transform.position.x, downHeight, transform.position.z);
    }
}
