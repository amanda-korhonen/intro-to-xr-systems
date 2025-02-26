using UnityEngine;

public class GameOver : MonoBehaviour
{
    public delegate void OnGameEnd();
    public static event OnGameEnd EndGame;
    public GameObject GameOverCanvas;

    public void GameOverAction()
   {
        EndGame();
   }
}
