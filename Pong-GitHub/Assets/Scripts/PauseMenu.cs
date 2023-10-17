using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameManager gameManager;
    public event Action<bool> OnResumeGame; // Evento para notificar a retomada do jogo

    private bool isPaused = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame(isPaused); // Passe isPaused ao chamar ResumeGame
            }
            else {
                PauseGame(isPaused); // Passe isPaused ao chamar PauseGame
            }
        }
    }

    public void PauseGame(bool isGameOver) {
        isPaused = true;
        gameObject.SetActive(true);
    }

    public void ResumeGame(bool isGameOver) {
        isPaused = false;
        Time.timeScale = 1; // Retoma o jogo
        OnResumeGame?.Invoke(isGameOver);
    }

    public void RestartGame() {
        gameManager.RestartGame();
        ResumeGame(isPaused); // Passe isPaused ao chamar ResumeGame
    }

    public void ExitGame() {
        Debug.Log("Sair!");
        //Application.Quit(); // Encerre a aplicação
    }
}