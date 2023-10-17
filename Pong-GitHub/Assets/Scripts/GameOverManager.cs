using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    public GameObject gameOverScreen;
    public GameObject winText;
    public GameObject loseText;
    public GameManager gameManager; // Adicione uma referência ao GameManager

    public void ShowGameOver(bool playerWins) {
        gameOverScreen.SetActive(true);

        if (playerWins) {
            winText.SetActive(true);
            loseText.SetActive(false);
        }
        else
        {
            winText.SetActive(false);
            loseText.SetActive(true);
        }
    }

    public void HideGameOver() {
        gameOverScreen.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    public void RestartGame() {
        gameManager.RestartGame(); // Chame a função RestartGame do GameManager
        HideGameOver(); // Oculte a tela de Game Over
    }

    public void ExitGame() {
        Debug.Log("Sair!");
        //Application.Quit(); // Encerre a aplicação
    }
}