using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGamePlayer : MonoBehaviour
{
    public static event Action OnPlayerDied;

    Rigidbody2D rb;
    GameObject player;

    private bool isFlap = false;
    private bool isDead = false;

    public float flapForce = 6f;
    public float Speed = 3f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (transform.position.y < -6f)
        {
            isDead = true;
        }

        if (isDead)
        {
            Debug.Log("Game Over");
            Destroy(player);
            OnPlayerDied?.Invoke();
        }
        else if (isDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }
    private void FixedUpdate()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string coinName = collision.gameObject.name.Replace("(Clone)", "");

        switch (coinName)
        {
            case "Coin_1":
                {
                    Debug.Log("Add : 1");
                    Destroy(collision.gameObject);
                    GameManager.Instance.AddCoin(1);
                    break;
                }
            case "Coin_2":
                {
                    Debug.Log("Add : 3");
                    Destroy(collision.gameObject);
                    GameManager.Instance.AddCoin(3);
                    break;
                }
            case "Coin_3":
                {
                    Debug.Log("Add : 2");
                    Destroy(collision.gameObject);
                    GameManager.Instance.AddCoin(2);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
