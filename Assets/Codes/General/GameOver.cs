using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    //panel
    public GameObject gameOverPanel;
    public TextMeshProUGUI winnerText;
    // er leik 
    private bool gameEnded = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    //sýnir hver vann
    public void ShowGameOver(string winner)
    {
        gameOverPanel.SetActive(true);
        winnerText.text = winner + " Wins!";
        gameEnded = true;

        // Freeze game
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
