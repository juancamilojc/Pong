using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour {
    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    [SerializeField]
    public int finalScore = 10;

    public event Action OnGameOver;
    public event Action OnPointScored;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball")) {
            if (gameObject.CompareTag("P1Score")) {
                UpdatePlayerScore();
                //Debug.Log("OnTriggerEnter2D() -> UpdatePlayerScore() // Scoreboard");
            }
            else if (gameObject.CompareTag("P2Score")) {
                UpdateEnemyScore();
                //Debug.Log("OnTriggerEnter2D() -> UpdateEnemyScore() // Scoreboard");
            }

            OnPointScored?.Invoke();
            //Debug.Log("OnTriggerEnter2D() -> OnPointScored?.Invoke() // Scoreboard");
        }
    }

    public int GetPlayerScore() {
        return scoreP1;
    }

    public int GetEnemyScore() {
        return scoreP2;
    }

    public void UpdatePlayerScore() {
        scoreP1++;
        p1ScoreText.text = scoreP1.ToString();
        CheckWinCondition(scoreP1);
        //Debug.Log("UpdatePlayerScore() // Scoreboard");
    }

    public void UpdateEnemyScore() {
        scoreP2++;
        p2ScoreText.text = scoreP2.ToString();
        CheckWinCondition(scoreP2);
        //Debug.Log("UpdateEnemyScore() // Scoreboard");
    }

    public void ResetPlayerScore() {
        scoreP1 = 0;
        p1ScoreText.text = "0";
    }

    public void ResetEnemyScore() {
        scoreP2 = 0;
        p2ScoreText.text = "0";
    }

    private void CheckWinCondition(int score) {
        if (score >= finalScore) {
            OnGameOver?.Invoke();
        }
    }
}