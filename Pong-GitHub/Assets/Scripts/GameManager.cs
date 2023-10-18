using UnityEngine;

public class GameManager : MonoBehaviour {
    public Ball ball;
    public Player player;
    public Enemy enemy;
    public Scoreboard playerScoreboard;
    public Scoreboard enemyScoreboard;

    public enum DifficultyLevel {
        Easy,
        Medium,
        Hard
    }

    public DifficultyLevel currentDifficulty = DifficultyLevel.Medium;
    public bool GameStarted { get; private set; }

    private void Awake() {
        OnScoreboardEvent();
        Invoke("StartGame", 0.5f);
    }

    private void OnScoreboardEvent() {
        playerScoreboard.OnPointScored += HandlePointScored;
        enemyScoreboard.OnPointScored += HandlePointScored;
        //Debug.Log("OnScoreboardEvent() // GameManager");
    }

    private void StartGame() {
        GameStarted = true;
        InitializeGame();
    }

    private void InitializeGame() {
        AdjustDifficulty();
        ball.InitializeMovement();
    }

    private void AdjustDifficulty() {
        float ballSpeed = 0f;
        float enemySpeed = 0f;
        float enemyErrorChance = 0f;

        switch (currentDifficulty) {
            case DifficultyLevel.Easy:
                ballSpeed = 5.0f;
                enemySpeed = 4.0f;
                enemyErrorChance = 0.6f;
                break;
            case DifficultyLevel.Medium:
                ballSpeed = 7.5f;
                enemySpeed = 6.0f;
                enemyErrorChance = 0.4f;
                break;
            case DifficultyLevel.Hard:
                ballSpeed = 10.0f;
                enemySpeed = 8.0f;
                enemyErrorChance = 0.2f;
                break;
        }

        ball.SetSpeed(ballSpeed);
        enemy.SetSpeed(enemySpeed);
        enemy.SetErrorChance(enemyErrorChance);
    }

    private void HandlePointScored() {
        ResetGameObjects();
        //Debug.Log("HandlePointScored() -> ResetGameObjects() // GameManager");
    }

    public void ResetGameObjects() {
        ball.ResetPosition();
        enemy.ResetPosition();
        //Debug.Log("ResetGameObjects() // GameManager");
    }

    public void RestartGame() {
        playerScoreboard.ResetPlayerScore();
        enemyScoreboard.ResetEnemyScore();
        player.ResetPosition();
        ResetGameObjects();
    }
}