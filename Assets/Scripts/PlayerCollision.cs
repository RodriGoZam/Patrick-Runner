using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    PlayerController playerController;
    Score score;

    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        score = FindObjectOfType<Score>();
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            playerController.Die();
            FindObjectOfType<GameManager>().EndGame(score.getCurrentScore());
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            playerController.Die();
            FindObjectOfType<GameManager>().EndGame(score.getCurrentScore());
        }
    }
}
