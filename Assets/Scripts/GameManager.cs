
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;

    public void EndGame(string score)
    {
        GameOverScreen.Setup(score);
    }
}
