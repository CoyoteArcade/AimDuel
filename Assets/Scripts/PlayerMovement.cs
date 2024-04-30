using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D body;
    new SpriteRenderer renderer;
    Animator animator;

    [SerializeField] float moveSpeed = 2.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Crouch();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run() {
        bool playerMovesDiagonal = Mathf.Abs(moveInput.x) > Mathf.Epsilon && Mathf.Abs(moveInput.y) > Mathf.Epsilon;

        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, body.velocity.y);
        body.velocity = playerVelocity;

        animator.SetBool("isRunning", Mathf.Abs(body.velocity.x) > Mathf.Epsilon);
    }

    void Crouch() {
        animator.SetBool("isCrouching", moveInput.y == -1);
    }

    void FlipSprite() {
        Vector3 playerScale = transform.localScale;
        bool playerMovesHorizontal = Mathf.Abs(body.velocity.x) > Mathf.Epsilon;

        // Flip sprite depending if moving left or right
        if (playerMovesHorizontal) {
            if (Mathf.Sign(body.velocity.x) == 1) {
                renderer.flipX = false;
            } else if (Mathf.Sign(body.velocity.x) == -1) {
                renderer.flipX = true;
            }
        }
    }
}
