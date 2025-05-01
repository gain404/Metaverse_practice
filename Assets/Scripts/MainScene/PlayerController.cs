using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    //�÷��̾ �޸��� �޸��� ��� �߰�
    //�÷��̾ �����ϸ� ���� �����ߴٰ� �ٽ� �Ʒ��� �����ɱ�

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

        //������ �ٲ�� �¿������ �ǰ�
        if (horizontal < 0f)
            spriteRenderer.flipX = true;
        else if (horizontal > 0f)
            spriteRenderer.flipX = false;

        //shift�� ������ �ٰ�
        bool isRun = Input.GetKey(KeyCode.LeftShift);

        if (isRun)
        {
            animator.SetBool("IsRun", isRun);
        }
    }

}
