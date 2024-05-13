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
    private bool isGrounded;
    private bool isAlive = true;
    private float initialDirection;

    // Variables for adjusting crouch hitbox of Player
    private Vector2 originalOffset;
    private Vector2 originalSize;
    [SerializeField] float crouchOffsetY = 0.09f;
    [SerializeField] float crouchSizeY = 1f;

    // Variables for Player knocked back when hit
    public float knockbackForce;
    public float knockbackCounter;
    public float knockbackTime;
    public bool knockFromRight;

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
        animator.SetBool("isGrounded", feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")));
        if (!isAlive) { return; }

        Midair();
        Run();
        Crouch();
        FlipSprite();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value) {
        if (!isAlive) { return; }

        if(value.isPressed && animator.GetBool("isGrounded")) {
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

        // Prevent movement when player is knocked back
        if (knockbackCounter <= 0) {
            body.velocity = playerVelocity;
        } else {
            if (knockFromRight) {
                initialDirection = -1;
                body.velocity = new Vector2(-knockbackForce, knockbackForce);
            } else {
                initialDirection = 1;
                body.velocity = new Vector2(knockbackForce, knockbackForce);
            }

            knockbackCounter -= Time.deltaTime;
        }

        // Keeps player momentum after falling off platform
        if (!playerIsMidair && moveInput.x != 0) {
            initialDirection = Mathf.Sign(moveInput.x);
        }

        animator.SetBool("isRunning", Mathf.Abs(body.velocity.x) > Mathf.Epsilon);
    }

    void Midair() {
        animator.SetFloat("jumpVelocity", body.velocity.y);
    }

    void Crouch() {
        bool isCrouching = moveInput.y == -1 && animator.GetBool("isGrounded");
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

    public void Die() {
        /*
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")) || feetCollider.IsTouchingLayers(LayerMask.GetMask("Enemy"))) {
            isAlive = false;
            animator.SetTrigger("Dead");
            body.velocity = new Vector2(0, body.velocity.y);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        }
        */
    }
}
