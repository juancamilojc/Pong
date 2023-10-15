using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scoreboard : MonoBehaviour {
    public Text p1ScoreText;
    public Text p2ScoreText;
    public Ball ball;
    public Enemy enemy;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball")) {
            if (gameObject.CompareTag("P1Score")) {
                UpdatePlayerScore();
            }
            else if (gameObject.CompareTag("P2Score")) {
                UpdateEnemyScore();
            }

            ResetGameObjects();
        }
    }

    private void ResetGameObjects() {
        ball.RepositionBall();
        enemy.RepositionEnemy();
    }

    public void UpdatePlayerScore() {
        scoreP1++;
        p1ScoreText.text = scoreP1.ToString();
    }

    public void UpdateEnemyScore() {
        scoreP2++;
        p2ScoreText.text = scoreP2.ToString();
    }
}