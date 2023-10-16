using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private float moveSpeed = 3.0f; // Velocidade da IA reduzida
    private Transform ball;
    private Rigidbody2D ballRigidbody;
    private float errorChance = 0.1f; // Taxa de erro padrão
    private Vector2 initialPosition;

    private void Awake() {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Define a posição inicial do Enemy

        if (ball == null || ballRigidbody == null) {
            Debug.LogError("Bola ou Rigidbody da bola não encontrados. Verifique a tag da bola e o Rigidbody.");
        }
    }

    public void SetSpeed(float newSpeed) {
        moveSpeed = newSpeed;
    }

    // Método para configurar a taxa de erro
    public void SetErrorChance(float newErrorChance) {
        errorChance = newErrorChance;
    }

    private void Update() {
        if (ball != null && ballRigidbody != null) {
            float timeToIntercept = Mathf.Abs((transform.position.x - ball.position.x) / ballRigidbody.velocity.x);
            float predictedY = ball.position.y + (ballRigidbody.velocity.y * timeToIntercept);

            if (Random.value < errorChance) {
                predictedY += Random.Range(-1f, 1f); // Erro aleatório com base na taxa de erro
            }

            if (transform.position.y < predictedY) {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else if (transform.position.y > predictedY) {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
        }
    }

    public void RepositionEnemy() {
        transform.position = initialPosition;
    }
}