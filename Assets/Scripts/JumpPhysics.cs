using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPhysics : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isFalling = body.velocity.y < 0;

        if (isFalling) {
            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}
