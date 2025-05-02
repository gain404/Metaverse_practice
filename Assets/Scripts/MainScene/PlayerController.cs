using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Animator animator;

    bool isJump = false;
    float jumpScale = 3f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector2(horizontal, vertical).normalized;
        transform.Translate(direction * Time.deltaTime * 4);

        PlayerFlip(horizontal); //좌우반전
        PlayerRun(direction); //달리기
        PlayerJump();

    }

    protected void PlayerFlip(float horizontal)
    {
        if (horizontal < 0f)
            spriteRenderer.flipX = true;
        else if (horizontal > 0f)
            spriteRenderer.flipX = false;
    }

    protected void PlayerRun(Vector3 direction)
    {
        bool isRun = Input.GetKey(KeyCode.LeftShift);

        if (isRun)
        {
            animator.SetBool("IsRun", true);
            transform.Translate(direction * Time.deltaTime * 4.5f);
        }
        else if (!isRun)
        {
            animator.SetBool("IsRun", false);
        }
    }

    protected void PlayerJump()
    {
        Vector3 jumpPos = transform.localPosition;
        float jumpVelocity = 3f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }

        if (isJump)
        {
            jumpVelocity -= 10f * Time.deltaTime;
            jumpPos.y += jumpScale * (jumpVelocity * Time.deltaTime);
            
            if (jumpPos.y <= 0f)
            {
                jumpPos.y = 0f;
                isJump = false;
                transform.localPosition = jumpPos;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "NPC2")
        {
            SceneManager.LoadScene("MiniGameScene");
        }
    }

}
