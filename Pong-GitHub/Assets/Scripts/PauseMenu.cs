using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameManager gameManager; // Referência para o GameManager no Unity

    public event Action OnResumeGame; // Evento para notificar a retomada do jogo

    private bool isPaused = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        isPaused = true;
        gameObject.SetActive(true);
    }

    public void ResumeGame() {
        isPaused = false;
        gameObject.SetActive(false);
        OnResumeGame?.Invoke(); // Dispara o evento de retomada do jogo
    }

    public void RestartGame() {
        gameManager.RestartGame();
        ResumeGame();
    }

    public void ExitGame() {
        Debug.Log("Sair!");
    }
}