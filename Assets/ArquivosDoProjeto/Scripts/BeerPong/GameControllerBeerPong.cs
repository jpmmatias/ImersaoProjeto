using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBeerPong : MonoBehaviour
{
    public TextMesh text;
    public BallBeerPong ball;
    public PlayerPlayBeerPong player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + ball.score;
        text.text += "\nForce: " + player.shootingTimer;
  
    }
}
