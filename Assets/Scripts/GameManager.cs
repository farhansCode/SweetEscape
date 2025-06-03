using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public TMP_Text livesText;

    public GameObject gameOverPanel; 



    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        UpdateLivesUI(); // Update once at start
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesUI();

        Debug.Log("Lives left: " + lives);

        if (lives <= 0)
        {
            EndGame();
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

   void EndGame()
{
    Debug.Log("Game Over!");

    Time.timeScale = 0f; // Pause the game

    if (gameOverPanel != null)
    {
        gameOverPanel.SetActive(true);
    }
    else
    {
        Debug.LogError("GameOverPanel not assigned!");
    }
}

public void RestartGame()
{
    Time.timeScale = 1f; // Unpause the game
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
}


}
