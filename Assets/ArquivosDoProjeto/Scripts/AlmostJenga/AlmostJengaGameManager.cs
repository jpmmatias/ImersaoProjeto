using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostJengaGameManager : MonoBehaviour

{
    private int points = 0;
    public SceneLoader SceneLoader;
  
    void Update()
    {
        if  (Input.GetButtonDown("Fire1"))
        {
            MovingCube.CurrentCube.Stop();
            MovingCube.CurrentCube.gameObject.GetComponent<Rigidbody>().useGravity = true;
            FindObjectOfType<CubeSpawner>().SpawnCube();
            points++;
            Debug.Log(points);

        }

        if (points > 5) {
            Debug.Log("win");
            StartCoroutine(loadCasa());

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
