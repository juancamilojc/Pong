using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    private bool isPaused = false;

    public bool IsGamePaused { get { return isPaused; } }

    public event Action<bool> OnPauseGame;

    public void PauseGame() {
        isPaused = true;
        Time.timeScale = 0;
        if (OnPauseGame != null) {
            OnPauseGame(true);
        }
    }

    public void ResumeGame() {
        isPaused = false;
        Time.timeScale = 1;
        if (OnPauseGame != null) {
            OnPauseGame(false);
        }
    }
}