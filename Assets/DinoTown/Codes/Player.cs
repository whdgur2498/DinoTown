using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 nextvec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) 
        {
            spriteRenderer.flipX = inputVec.x < 0;
        }
    }
}
