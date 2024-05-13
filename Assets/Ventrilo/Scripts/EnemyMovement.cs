using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] bool startLeft = false;
    EnemyHealth enemyHealth;
    Rigidbody2D rigidBody;
    Animator animator;
    SpriteRenderer renderer;
    public float freezeTime = 0.25f;
    private bool isAlive = true;
    // SpriteRenderer renderer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        renderer = GetComponent<SpriteRenderer>();

        if (startLeft) {
            moveSpeed *= -1;
            FlipSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        rigidBody.velocity = new Vector2(moveSpeed, 0f);
        checkEnemyHealth();
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag != "Player") {
            moveSpeed = -moveSpeed;
            FlipSprite();
        }
    }

    void FlipSprite() {
        transform.localScale = new Vector2(-Mathf.Sign(rigidBody.velocity.x), 1f);
    }

    public IEnumerator FreezeEnemy() {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(freezeTime);

        if (rigidBody != null) {
            rigidBody.constraints = RigidbodyConstraints2D.None;
        }
    }

    void checkEnemyHealth() {
        if (enemyHealth.health <= 0) {
            isAlive = false;
            animator.SetTrigger("Dead");
        }
    }

    public void Die() {
        Destroy(this.gameObject);
    }
}
