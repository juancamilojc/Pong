using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    private bool isPaused = false;
    public GameObject pauseMenuScreen; // Referência para a tela do menu de pausa no Unity
    public GameObject gameOverScreen; // Referência para a tela de Game Over no Unity
    private bool isGameOver = false; // Variável para indicar se é um Game Over

    private void Start() {
        var pauseMenuComponent = pauseMenuScreen.GetComponent<PauseMenu>();
        pauseMenuComponent.OnResumeGame += (isGameOver) => ResumeGame(isGameOver);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) {
            PauseGame(isGameOver);
        } else if (isPaused) {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
                ResumeGame(isGameOver);
            }
        }
    }

    public void PauseGame(bool isGameOver) {
        this.isGameOver = isGameOver;
        isPaused = true;
        Time.timeScale = 0;

        if (isGameOver) {
            gameOverScreen.SetActive(true);
        } else {
            pauseMenuScreen.SetActive(true);
        }
    }

    public void ResumeGame(bool isGameOver) {
        isPaused = false;
        Time.timeScale = 1;

        if (isGameOver) {
            gameOverScreen.SetActive(false);
        } else {
            pauseMenuScreen.SetActive(false);
        }
    }
}