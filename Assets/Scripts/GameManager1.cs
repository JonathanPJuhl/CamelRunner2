using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{

    int score;
    public static GameManager1 inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovementController playerMovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
        if (playerMovement.speed > 20)
        {
            playerMovement.leftAndRightMultiplier -= 0.01f;
        }
    }
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
