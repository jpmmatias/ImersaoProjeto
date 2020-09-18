using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFlipCup : MonoBehaviour
{
  
    
        public SceneLoader sceneLoader;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                //sceneLoader.LoadFlipCup();
            }
        }
    
}
