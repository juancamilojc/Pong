using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Ball ball;
    public Player player;
    public Enemy enemy;
    public Scoreboard playerScoreboard;
    public Scoreboard enemyScoreboard;

    private float ballSpeed = 5.0f; // Valor padrão da velocidade da bola
    private float enemySpeed = 4.0f; // Valor padrão da velocidade da IA

    private float enemyErrorChance = 0.1f; // Taxa de erro padrão

    public enum DifficultyLevel {
        Easy,
        Medium,
        Hard
    }

    public DifficultyLevel currentDifficulty = DifficultyLevel.Medium;

    private bool gameStarted = false; // Propriedade para rastrear se o jogo foi iniciado
    private bool gamePaused = false;

    public bool GameStarted {
        get { return gameStarted; }
    }

    private void Update() {
        if (!gameStarted) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                StartGame();
            }
        } else if (gameStarted && !gamePaused && Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        } else if (gameStarted && gamePaused && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))) {
            ResumeGame();
        }
    }

    private void StartGame() {
        gameStarted = true;
        InitializeGame();
    }

    private void PauseGame() {
        Time.timeScale = 0; // Pausar o jogo
        gamePaused = true;
    }

    private void ResumeGame() {
        Time.timeScale = 1; // Retomar o jogo
        gamePaused = false;
    }

    private void InitializeGame() {
        // Ajusta a velocidade da bola e da IA com base na dificuldade
        AdjustDifficulty();

        // Inicia a bola
        ball.SetSpeed(ballSpeed);
        ball.InitializeMovement();
    }

    private void AdjustDifficulty() {
        switch (currentDifficulty) {
            case DifficultyLevel.Easy:
                ballSpeed = 5.0f;
                enemySpeed = 4.0f;
                enemyErrorChance = 0.3f; // Taxa de erro mais alta
                break;
            case DifficultyLevel.Medium:
                ballSpeed = 7.5f;
                enemySpeed = 6.0f;
                enemyErrorChance = 0.2f; // Taxa de erro moderada
                break;
            case DifficultyLevel.Hard:
                ballSpeed = 10.0f;
                enemySpeed = 8.0f;
                enemyErrorChance = 0.1f; // Taxa de erro mais baixa
                break;
        }

        //Atualiza a velocidade e a taxa de erro da IA de acordo com a dificuldade
        enemy.SetSpeed(enemySpeed);
        enemy.SetErrorChance(enemyErrorChance);
    }

    public void SetDifficulty(DifficultyLevel difficulty) {
        // Configura a dificuldade com base no valor passado
        currentDifficulty = difficulty;
        AdjustDifficulty();
    }

    public void PlayerScored() {
        // Player marcou ponto, atualiza a pontuação do jogador e reinicia o jogo
        playerScoreboard.UpdatePlayerScore();
        RestartGame();
    }

    public void EnemyScored() {
        // Enemy marcou ponto, atualiza a pontuação do inimigo e reinicia o jogo
        enemyScoreboard.UpdateEnemyScore();
        RestartGame();
    }

    private void RestartGame() {
        // Reposiciona a bola e a IA
        ball.RepositionBall();
        enemy.RepositionEnemy();
    }
}