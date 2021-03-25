using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform Patrick;
    public Text scoreText;
    int currentScore;
    PlayerController playerContoller;
    int nextSpeedIncrease;

    private void Start()
    {
        playerContoller = GameObject.FindObjectOfType<PlayerController>();
        nextSpeedIncrease = 100;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = (int)Patrick.position.z;//.ToString("0");
        scoreText.text = "Score: " + currentScore.ToString();

        if (currentScore.Equals(nextSpeedIncrease))
        {
            playerContoller.increaseSpeed();
            nextSpeedIncrease = nextSpeedIncrease * 2;
        }
    }

    public string getCurrentScore()
    {
        return currentScore.ToString();
    }
}
