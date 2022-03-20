using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool isGameOver;

    [SerializeField]
    private GameObject gameOverScreen;

    public Button restartButton;

    private void Start()
    {
        isGameOver = false;
        Time.timeScale = 1;
        restartButton = GetComponent<Button>();
    }

    private void Update()
    {
        if(isGameOver == true)
        {
            Time.timeScale = 0.0f;
            gameOverScreen.SetActive(true); // Will deploy the game over screen if the ball falls through or has a collision
        }

        restartButton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Version_1.1");
    }
}
