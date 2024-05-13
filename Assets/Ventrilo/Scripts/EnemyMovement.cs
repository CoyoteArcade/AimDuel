using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidBody;
    public float freezeTime = 0.25f;
    // SpriteRenderer renderer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(moveSpeed, 0f);
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

        rigidBody.constraints = RigidbodyConstraints2D.None;
    }
}
