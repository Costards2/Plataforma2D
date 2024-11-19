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
        animator.SetBool("wallSlide", false);
    }

    public void PlayRun()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", true);
        animator.SetBool("fall", false);
        animator.SetBool("jump", false);
        animator.SetBool("wallSlide", false);
    }

    public void PlayFall()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", true);
        animator.SetBool("jump", false);
        animator.SetBool("wallSlide", false);
    }

    public void PlayJump()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", false);
        animator.SetBool("jump", true);
        animator.SetBool("wallSlide", false);
    }

    public void PlayDoubleJump()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", false);
        animator.SetBool("jump", false);
        animator.SetBool("wallSlide", false);

        animator.SetTrigger("doubleJump");
    }

    public void PlayWallSlide()
    {
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", false);
        animator.SetBool("jump", false);
        animator.SetBool("wallSlide", true);
    }

    public void PlayDamage()
    {
        // ******** Not necessary ************* 
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", false);
        animator.SetBool("jump", false);
        animator.SetBool("wallSlide", false);
        // ************************************

        animator.SetTrigger("damage");
    }

    public void PlayDeath()
    {
        // ******** Not necessary ************* 
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("fall", false);
        animator.SetBool("jump", false);
        animator.SetBool("wallSlide", false);
        // ************************************

        animator.SetTrigger("death");
    }
}
