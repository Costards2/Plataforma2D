using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        animator.SetBool("idle", true);
        animator.SetBool("run", false);
        animator.SetBool("fall", false);
        animator.SetBool("jump", false);
    }

    public void PlayRun()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", true);
        animator.SetBool("fall", false);
        animator.SetBool("jump", false);
    }

    public void PlayFall()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", true);
        animator.SetBool("jump", false);
    }

    public void PlayJump()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", false);
        animator.SetBool("jump", true);
    }

    public void PlayDoubleJump()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", false);
        animator.SetBool("jump", false);

        animator.SetTrigger("doubleJump");
    }
}
