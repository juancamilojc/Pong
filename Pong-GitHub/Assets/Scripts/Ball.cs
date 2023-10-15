using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    private float speed = 5.0f;

    private Vector2 initialDirection;
    private Vector2 initialPosition;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Define o modo de detecção de colisão como Contínuo
        rb.velocity = Vector2.zero; // Garante que a velocidade seja zero ao iniciar
    }

    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }

    public void InitializeMovement() {
        float directionX = Random.Range(0, 2) == 0 ? -1 : 1;
        float directionY = Random.Range(0, 2) == 0 ? -1 : 1;
        initialDirection = new Vector2(speed * directionX, speed * directionY);

        rb.velocity = initialDirection;
    }

    public void RepositionBall() {
        transform.position = Vector3.zero;
        InitializeMovement();
    }
}