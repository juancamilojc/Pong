using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float speed = 5.0f;
    private GameManager gameManager;
    private Vector2 initialPosition;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
        initialPosition = transform.position;
    }

    private void FixedUpdate() {
        if (gameManager.GameStarted) {
            MovePlayer();
        }
    }

    private void MovePlayer() {
        float moveInput = Input.GetAxis("Vertical");
        float moveMagnitude = Mathf.Abs(moveInput);
        Vector2 movement = new Vector2(0.0f, moveInput * speed * Time.fixedDeltaTime);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = movement;
        rb.position = new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, -5, 5));
    }

    public void ResetPosition() {
        transform.position = initialPosition;
        //Debug.Log("ResetPosition() // Player");
    }
}