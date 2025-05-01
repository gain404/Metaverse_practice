using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    //플레이어가 달리면 달리는 모션 추가
    //플레이어가 점프하면 위로 점프했다가 다시 아래로 내려앉기

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector2(horizontal, vertical).normalized;

        transform.Translate(direction * Time.deltaTime * 4);

        //방향이 바뀌면 좌우반전이 되게
        if (horizontal < 0f)
            spriteRenderer.flipX = true;
        else if (horizontal > 0f)
            spriteRenderer.flipX = false;

        //shift를 누르면 뛰게
        bool isRun = Input.GetKey(KeyCode.LeftShift);

        if (isRun)
        {
            animator.SetBool("IsRun", isRun);
        }
    }

}
