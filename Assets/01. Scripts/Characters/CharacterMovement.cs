using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterAnimation anim;
    [SerializeField] private SpriteRenderer spr;
    public float hSpeed = 3.5f;
    public float vSpeed = 2.1f;
    bool facingRight = true;
    bool isJumping = false;
    bool isAttacking = false;

    void Awake()
    {
        anim = GetComponent<CharacterAnimation>();
        spr = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    public void Move(float hMove, float vMove)//이동
    {
        this.transform.Translate(hMove * Time.deltaTime * hSpeed, vMove * Time.deltaTime * vSpeed, 0);

        if (hMove > 0 && !facingRight) //좌우 반전
        {
            facingRight = !facingRight;
            spr.flipX = facingRight;
        }
        else if (hMove < 0 && facingRight)
        {
            facingRight = !facingRight;
            spr.flipX = facingRight;
        }

        if(Mathf.Abs(hMove) + Mathf.Abs(vMove) != 0) //이동 체크
        {
            anim.Moving();
        }
        else
        {
            anim.EndMoving();
        }
    }

    public void Jump()
    {
        if (!isJumping)
        {
            StartCoroutine(Jumping());
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            StartCoroutine(Attacking());
        }
    }

    IEnumerator Jumping() //점프 처리
    {
        isJumping = true;
        anim.Jump();
        yield return new WaitForSeconds(1.2f); //애니메이션 길이
        anim.EndJump();
        isJumping = false;
    }

    IEnumerator Attacking() //공격 처리
    {
        isAttacking = true;
        anim.Attack();
        yield return new WaitForSeconds(0.25f); //애니메이션 길이
        anim.EndAttack();
        isAttacking = false;
    }
}
