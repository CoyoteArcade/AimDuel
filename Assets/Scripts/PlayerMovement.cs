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

    [SerializeField] float moveSpeed = 2.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, body.velocity.y);
        body.velocity = playerVelocity;
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
