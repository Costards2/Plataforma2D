using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForceY = 1.5f;
    public float jumpForceX = 0f;

    private bool isJumping = false;
    private bool doubleJump = false;

    private bool enableJump = false;

    private Coroutine jumpCoroutine;

    void Update()
    {
        if(PlayerManager.instance.enableMovement == false) return;
        Move();
        Jump();
        WallSlide();
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");

        // Verify if the player arrived the extremity
        if (xInput > 0 && PlayerManager.playerRight.RightLimit)
        {
            xInput = 0;
        }
        else if (xInput < 0 && PlayerManager.playerLeft.LeftLimit)
        {
            xInput = 0;
        }

        // Verify wich side to look
        if (xInput > 0)
        {
            PlayerManager.flipPlayerBody.LookRight();
        }
        else if (xInput < 0)
        {
            PlayerManager.flipPlayerBody.LookLeft();
        }

        //verify if player is on the ground
        if (PlayerManager.playerFeet.OnGround)
        {
            if (xInput != 0)
            {
                PlayerManager.playerAnimation.PlayRun();
            }
            else
            {
                PlayerManager.playerAnimation.PlayIdle();
            }
        }
        else
        {
            PlayerManager.playerAnimation.PlayFall();
        }

        // Move Player
        Vector3 moveDirection = new Vector3(xInput, 0, 0);
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (enableJump) 
            {
                PlayerManager.playerAnimation.PlayJump();
                enableJump = false;
                isJumping = true;
                doubleJump = true;
                ActivateJumpTime();
            }
            else
            {
                if (doubleJump)
                {
                    PlayerManager.playerAnimation.PlayDoubleJump();
                    isJumping = true;
                    doubleJump = false;
                    ActivateJumpTime();
                }
            }
        }

        if(isJumping) 
        {
            if (!PlayerManager.playerHead.HeadLimit)
            {
                PlayerManager.rigidbody2D.velocity = Vector3.zero;
                PlayerManager.rigidbody2D.gravityScale = 1;
                Vector3 jumpDirection = new Vector3 (jumpForceX, jumpForceY, 0);
                transform.position += jumpDirection * speed * Time.deltaTime;
            }   
        }
        else
        {
            PlayerManager.rigidbody2D.gravityScale = 4;
        }
    }

    public void ActivateJumpTime()
    {
        if(jumpCoroutine != null)
        {
           StopCoroutine(jumpCoroutine);
        }

        jumpCoroutine = StartCoroutine(JumpTime());
    }

    public void EnableJump()
    {
        enableJump = true;
    }

    public void CancelJump()
    {
        if (jumpCoroutine != null)
        {
            StopCoroutine (jumpCoroutine);
        }
        jumpForceX = 0;
        isJumping = false;
    }

    private IEnumerator JumpTime()
    {
        yield return new WaitForSeconds(0.3f);
        jumpForceX = 0;
        isJumping = false;
    }

    //This is also the Wall Jump
    void WallSlide()
    {
        if(!PlayerManager.playerFeet.OnGround && PlayerManager.playerHead.HeadLimit == false && (PlayerManager.playerRight.RightLimit || PlayerManager.playerLeft.LeftLimit))
        {
            PlayerManager.playerAnimation.PlayWallSlide();

            if (Input.GetButtonDown("Jump"))
            {
                jumpForceX = PlayerManager.flipPlayerBody.LeftOrRight == true ? jumpForceY : jumpForceY * -1;

                isJumping = true;
                doubleJump = true;
                PlayerManager.playerAnimation.PlayJump();
                ActivateJumpTime();
            }
        }
    }
}
