using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private Rigidbody2D rb2D;

    private InputHandler inputHandler;
    [SerializeField] private float jumpForce;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleJumping();
    }

    private void HandleMovement()
    {
        rb2D.velocity = inputHandler.MoveInput * movementSpeed;
    }

    private void HandleJumping()
    {
        // Apply upward force to the character for jumping.
        rb2D.AddForce(Vector2.up * jumpForce * inputHandler.JumpInput, ForceMode2D.Impulse);
    }
}
