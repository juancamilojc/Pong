using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float speed = 5.0f;

    private GameManager gameManager; // Referência ao GameManager

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate() {
        if (gameManager.GameStarted) { // Verifica se o jogo já começou
            MovePlayer();
        }
    }

    private void MovePlayer() {
        float moveInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, moveInput * speed * Time.fixedDeltaTime, 0.0f);

        // Move o jogador usando Rigidbody para melhor simulação física
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = movement;

        // Limita a posição vertical do jogador
        rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, -5, 5));
    }

    public void RepositionPlayer() {
        transform.position = new Vector3(transform.position.x, 0, 0);
    }
}