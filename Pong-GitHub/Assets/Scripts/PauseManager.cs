using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    private bool isPaused = false;
    public GameObject pauseMenu; // Referência para o menu de pausa no Unity

    private void Start() {
        var pauseMenuComponent = pauseMenu.GetComponent<PauseMenu>();
        pauseMenuComponent.OnResumeGame += ResumeGame;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) {
            PauseGame();
        } else if (isPaused) {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
                ResumeGame();
            }
        }
    }

    public void PauseGame() {
        isPaused = true;
        Time.timeScale = 0; // Pausa o jogo

        // Ativa o menu de pausa
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        isPaused = false;
        Time.timeScale = 1; // Retoma o jogo

        // Desativa o menu de pausa
        pauseMenu.SetActive(false);
    }
}