using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
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
