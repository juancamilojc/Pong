using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public GameManager gameManager;
    public PauseManager pauseManager;
    public GameObject gameOverScreen;
    public GameObject winText;
    public GameObject loseText;
    public Scoreboard playerScoreboard;
    public Scoreboard enemyScoreboard;
    [SerializeField]
    private string Scene;
    private bool isGameOverScreenActive = false;

    public bool IsGameOverScreenActive { get { return isGameOverScreenActive; } }

    private void Awake() {
        playerScoreboard.OnGameOver += HandleGameOver;
        enemyScoreboard.OnGameOver += HandleGameOver;
        //Debug.Log("Awake() -> // GameOverManager");
    }

    public void ShowGameOver() {
        isGameOverScreenActive = true;
        pauseManager.PauseGame();
        gameOverScreen.SetActive(true);

        int playerScore = playerScoreboard.GetPlayerScore();
        int enemyScore = enemyScoreboard.GetEnemyScore();

        if (playerScore > enemyScore) {
            winText.SetActive(true);
            loseText.SetActive(false);
        } else {
            winText.SetActive(false);
            loseText.SetActive(true);
        }
    }

    public void HideGameOver() {
        isGameOverScreenActive = false;
        winText.SetActive(false);
        loseText.SetActive(false);
        gameOverScreen.SetActive(false);
        pauseManager.ResumeGame();
    }

    public void OnRestartButtonClicked() {
        HideGameOver();
        gameManager.RestartGame();
    }

    public void OnReturnMainMenuButtonClicked() {
        SceneManager.LoadScene(Scene);
    }

    public void OnExitButtonClicked() {
        Debug.Log("Sair!");
        //Application.Quit();
    }

    private void HandleGameOver() {
        ShowGameOver();
    }
}