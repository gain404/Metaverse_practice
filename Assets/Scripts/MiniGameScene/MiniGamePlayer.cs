using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public float flapForce = 6f;
    public float Speed = 3f;

    bool isFlap = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isFlap = true;
        }
    }

    private void FixedUpdate() //물리 관련 update
    {
        Vector3 velocity = rb.velocity;
        velocity.x = Speed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        rb.velocity = velocity;

    }

}
