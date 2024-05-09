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
    public Transform attackPoint;
    public float attackRange = 0.2f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if(value.isPressed) {
            animator.SetTrigger("Attack");
            Attack();
        }
    }

    void Attack() {
        // Detect enemies within attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage detected enemies
        foreach(Collider2D enemy in hitEnemies) {
            Debug.Log("We hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
