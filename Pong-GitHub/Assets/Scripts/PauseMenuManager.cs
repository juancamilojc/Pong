using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour {
    public GameManager gameManager;
    public GameOverManager gameOverManager;
    public PauseManager pauseManager;
    public GameObject pauseMenuScreen;

    private void Start() {
        pauseManager.OnPauseGame += HandlePauseGame;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseManager.IsGamePaused && !gameOverManager.IsGameOverScreenActive) {
                pauseManager.ResumeGame();
                HidePauseMenu();
            } else {
                if (!gameOverManager.IsGameOverScreenActive) {
                    pauseManager.PauseGame();
                    ShowPauseMenu();
                }
            }
        }
    }

    /* --- Update() v1
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
            if (pauseManager.IsGamePaused) {
                pauseManager.ResumeGame();
                HidePauseMenu();
            } else if (!gameOverManager.IsGameOverScreenActive) {
                pauseManager.PauseGame();
                ShowPauseMenu();
            }
        }
    }
    */

    public void ShowPauseMenu() {
        pauseMenuScreen.SetActive(true);
    }

    public void HidePauseMenu() {
        pauseMenuScreen.SetActive(false);
    }

    public void OnResumeButtonClicked() {
        pauseManager.ResumeGame();
        HidePauseMenu();
    }

    public void OnRestartButtonClicked() {
        gameManager.RestartGame();
        pauseManager.ResumeGame();
        HidePauseMenu();
    }

    public void OnExitButtonClicked() {
        Debug.Log("Sair!");
        //Application.Quit();
    }

    private void HandlePauseGame(bool isGamePaused) {
        if (isGamePaused && !gameOverManager.IsGameOverScreenActive) {
            ShowPauseMenu();
        } else {
            HidePauseMenu();
        }
    }
}