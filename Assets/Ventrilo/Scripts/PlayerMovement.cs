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
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;
    new SpriteRenderer renderer;
    Animator animator;

    [SerializeField] float moveSpeed = 2.1f;
    [SerializeField] float jumpSpeed = 8f;
    private float initialDirection;

    private Vector2 originalOffset;
    private Vector2 originalSize;
    [SerializeField] float crouchOffsetY = 0.09f;
    [SerializeField] float crouchSizeY = 1f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();

        originalOffset = bodyCollider.offset;
        originalSize = bodyCollider.size;
    }

    void Update()
    {
        Midair();
        Run();
        Crouch();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value) {
        bool isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if(value.isPressed && isGrounded) {
            // Gets initial direction after jumping
            if (moveInput.x != 0) {
                initialDirection = Mathf.Sign(moveInput.x);
            } else {
                initialDirection = 0;
            }

            body.velocity = Vector2.up * jumpSpeed;
        }
    }

    void Run() {
        bool playerMovesDiagonal = Mathf.Abs(moveInput.x) > Mathf.Epsilon && Mathf.Abs(moveInput.y) > Mathf.Epsilon;
        bool playerAttacksOnGround = animator.GetBool("isGrounded") && animator.GetBool("isAttacking");
        bool playerIsMidair = !animator.GetBool("isGrounded");

        Vector2 playerVelocity;
        
        if (playerAttacksOnGround) {
            // Keeps player from moving when attacking on ground
            playerVelocity = new Vector2(0, body.velocity.y);
        } else if (playerIsMidair) {
            // Prevents player from changing direction midair
            playerVelocity = new Vector2(initialDirection * moveSpeed, body.velocity.y);
        } else if (playerMovesDiagonal) {
            // Keeps speed from slowing down when input is diagonal
            playerVelocity = new Vector2(Mathf.Sign(moveInput.x) * moveSpeed, body.velocity.y);
        } else {
            playerVelocity = new Vector2(moveInput.x * moveSpeed, body.velocity.y);
        }

        body.velocity = playerVelocity;

        // Keeps player momentum after falling off platform
        if (!playerIsMidair && moveInput.x != 0) {
            initialDirection = Mathf.Sign(moveInput.x);
        }

        animator.SetBool("isRunning", Mathf.Abs(body.velocity.x) > Mathf.Epsilon);
    }

    void Midair() {
        animator.SetBool("isGrounded", feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")));
        animator.SetFloat("jumpVelocity", body.velocity.y);
    }

    void Crouch() {
        bool isCrouching = moveInput.y == -1 && feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        animator.SetBool("isCrouching", isCrouching);

        if (isCrouching) {
            bodyCollider.offset = new Vector2(originalOffset.x, originalOffset.y - crouchOffsetY);
            bodyCollider.size = new Vector2(originalSize.x, originalSize.y - crouchSizeY);
        } else {
            bodyCollider.offset = originalOffset;
            bodyCollider.size = originalSize;
        }
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
