using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    [SerializeField] new SpriteRenderer renderer;

    // Collider used to edit hitbox size and visual reference for testing purposes
    [SerializeField] CapsuleCollider2D hitboxCollider; 

    public Transform attackPoint;
    public LayerMask enemyLayers;
    private Vector2 attackRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attackRange = hitboxCollider.size;
    }

    void Update() {
        // Set attacking state
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    void OnAttack(InputValue value) {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Hurt")) {
            return;
        }

        if(value.isPressed) {
            // Flip attack point direction if sprite flipped
            Vector3 attackPos = attackPoint.localPosition;
            if (renderer.flipX == true) {
                attackPoint.localPosition = new Vector3(-1 * Mathf.Abs(attackPos.x), attackPos.y, attackPos.z);
            } else {
                attackPoint.localPosition = new Vector3(Mathf.Abs(attackPos.x), attackPos.y, attackPos.z);
            }

            // Play animation and deal damage
            animator.SetTrigger("Attack");
        }
    }

    public void Attack() {
        // Detect enemies within attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCapsuleAll(attackPoint.position, attackRange, CapsuleDirection2D.Horizontal, 0, enemyLayers);

        // Damage detected enemies
        foreach(Collider2D enemy in hitEnemies) {
            Debug.Log("We hit " + enemy.name);
        }
    }
}
