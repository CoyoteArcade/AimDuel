using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    CapsuleCollider2D enemyBody;

    void Start() {
        enemyBody = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (enemyBody.IsTouchingLayers(LayerMask.GetMask("Player"))) {
            playerMovement.knockbackCounter = playerMovement.knockbackTime;
            
            if (playerMovement.gameObject.transform.position.x <= transform.position.x) {
                playerMovement.knockFromRight = true;
            } else {
                playerMovement.knockFromRight = false;
            }

            playerHealth.DamagePlayer(damage);
        }
    }
}
