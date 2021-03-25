using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    public Text ScoreText;

    public void Setup(string score)
    {
        gameObject.SetActive(true);
        ScoreText.text = "Yout Score was: "+score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
