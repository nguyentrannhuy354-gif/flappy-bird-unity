using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerControls controls;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    public void StartGame()
    {
        Debug.Log("start");
        rb.simulated = true;
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Gamelay.Jump.performed += OnJump;
    }
    private void OnDisable()
    {
        controls.Gamelay.Jump.performed -= OnJump;
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (gameManager.currentState == GameManager.GameState.Start)
        {
            gameManager.startGame();
        }
        rb.linearVelocity = Vector2.up * 6.5f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            gameManager.AddScore();
        }
    }

    public void resetPlayer()
    {
        transform.position = new Vector3(-5.6f, 2.3f, 0);

    }
}
