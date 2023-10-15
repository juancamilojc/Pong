using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Ball ball;
    public Player player;
    public Enemy enemy;
    public Scoreboard playerScoreboard;
    public Scoreboard enemyScoreboard;

    private float ballSpeed = 5.0f;
    private float enemySpeed = 4.0f;
    private float enemyErrorChance = 0.1f;

    public enum DifficultyLevel {
        Easy,
        Medium,
        Hard
    }

    public DifficultyLevel currentDifficulty = DifficultyLevel.Medium;

    private bool gameStarted = false;

    public bool GameStarted {
        get { return gameStarted; }
    }

    private void Update() {
        if (!gameStarted) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                StartGame();
            }
        }
    }

    private void StartGame() {
        gameStarted = true;
        InitializeGame();
    }

    private void InitializeGame() {
        AdjustDifficulty();
        ball.SetSpeed(ballSpeed);
        ball.InitializeMovement();
    }

    private void AdjustDifficulty() {
        switch (currentDifficulty) {
            case DifficultyLevel.Easy:
                ballSpeed = 5.0f;
                enemySpeed = 4.0f;
                enemyErrorChance = 0.3f;
                break;
            case DifficultyLevel.Medium:
                ballSpeed = 7.5f;
                enemySpeed = 6.0f;
                enemyErrorChance = 0.2f;
                break;
            case DifficultyLevel.Hard:
                ballSpeed = 10.0f;
                enemySpeed = 8.0f;
                enemyErrorChance = 0.1f;
                break;
        }

        enemy.SetSpeed(enemySpeed);
        enemy.SetErrorChance(enemyErrorChance);
    }

    public void SetDifficulty(DifficultyLevel difficulty) {
        currentDifficulty = difficulty;
        AdjustDifficulty();
    }

    public void PlayerScored() {
        playerScoreboard.UpdatePlayerScore();
        playerScoreboard.ResetGameObjects();
    }

    public void EnemyScored() {
        enemyScoreboard.UpdateEnemyScore();
        enemyScoreboard.ResetGameObjects();
    }
}