using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public static MovingCube CurrentCube { get;private set;}
    public static MovingCube LastCube { get; private set; }
     public AlmostJengaGameManager gameManager;
    public SceneLoader SceneLoader;
    private float hangover;

    private void OnEnable()
    {
        SceneLoader = GameObject.Find("LevelLoader").GetComponent<SceneLoader>(); 
        if (LastCube == null)
        {
            LastCube = GameObject.Find("startCube").GetComponent<MovingCube>();
        }
        else { CurrentCube = this; }
        
       
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
        this.moveSpeed = 0f;
        LastCube = this;
  
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floorJenga"))
        {
            //StartCoroutine(loadCasa());
            Debug.Log("lose");
        }
    }

    public IEnumerator loadCasa()
    {
        yield return new WaitForSeconds(2f);
        loadScene();
    }

    public void loadScene()
    {
        SceneLoader.LoadCasaScene();
    }
}
