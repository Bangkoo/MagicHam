using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private Transform sprPos;

    void Awake()
    {
        animator = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
        sprPos = this.transform.GetChild(0).gameObject.GetComponent<Transform>();
    }

    public void Jump() //����
    {
        animator.SetBool("IsJumping", true);
    }
    public void EndJump() //���� �� ����
    {
        animator.SetBool("IsJumping", false);
    }

    public void Moving()
    {
        animator.SetBool("IsMoving", true);
    }
    public void EndMoving()
    {
        animator.SetBool("IsMoving", false);
    }

    public void Attack()
    {
        animator.SetBool("IsAttacking", true);
    }
    public void EndAttack()
    {
        animator.SetBool("IsAttacking", false);
    }
}
