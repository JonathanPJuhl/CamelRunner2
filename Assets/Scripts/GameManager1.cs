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
        if (playerMovement.speed > 20f)
        {
            playerMovement.leftAndRightMultiplier *= 0.95f;
        }
    }
    public void ActivatePowerUp(string name)
    {
        if (name == "PowerUp_SpeedUp")
        {
            StartCoroutine("SpeedUpEnd");
        }
        if (name == "PowerUp_speeddown")
        {
            StartCoroutine("SpeedDownEnd");
        }
    }
    IEnumerator SpeedUpEnd()
    {
        playerMovement.speed += 5;
        yield return new WaitForSeconds(4f);
        playerMovement.speed -= 5;
    }
    IEnumerator SpeedDownEnd()
    {
        playerMovement.speed -= 5;
        yield return new WaitForSeconds(4f);
        playerMovement.speed += 5;
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
