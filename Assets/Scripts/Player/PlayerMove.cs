using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForceY = 1.5f;

    private PlayerRight playerRight;
    private PlayerLeft playerLeft;
    private FlipPlayerBody flipPlayerBody;
    private PlayerFeet playerFeet;
    private PlayerHead playerHead;
    private PlayerAnimation playerAnimation;

    private Rigidbody2D rb;

    private bool isJumping = false;
    private bool doubleJump = false;

    private Coroutine jumpCoroutine;

    void Start()
    {
        playerRight = GetComponentInChildren<PlayerRight>();
        playerLeft = GetComponentInChildren<PlayerLeft>();
        flipPlayerBody = GetComponentInChildren<FlipPlayerBody>();
        playerAnimation = GetComponentInChildren<PlayerAnimation>();
        playerFeet = GetComponentInChildren<PlayerFeet>();
        playerHead = GetComponentInChildren<PlayerHead>();  

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");

        // Verify if the player arrived the extremity
        if (xInput > 0 && playerRight.RightLimit)
        {
            xInput = 0;
        }
        else if (xInput < 0 && playerLeft.LeftLimit)
        {
            xInput = 0;
        }

        // Verify wich side to look
        if (xInput > 0)
        {
            flipPlayerBody.LookRight();
        }
        else if (xInput < 0)
        {
            flipPlayerBody.LookLeft();
        }

        //verify if player is on the ground
        if (playerFeet.OnGround)
        {
            if (xInput != 0)
            {
                playerAnimation.PlayRun();
            }
            else
            {
                playerAnimation.PlayIdle();
            }
        }
        else
        {
            playerAnimation.PlayFall();
        }

        // Move Player
        Vector3 moveDirection = new Vector3(xInput, 0, 0);
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (playerFeet.OnGround) 
            {
                playerAnimation.PlayJump();
                isJumping = true;
                doubleJump = true;
                ActivateJumpTime();
            }
            else
            {
                if (doubleJump)
                {
                    playerAnimation.PlayDoubleJump();
                    isJumping = true;
                    doubleJump = false;
                    ActivateJumpTime();
                }
            }
        }

        if(isJumping) 
        {
            if (!playerHead.HeadLimit)
            {
                rb.velocity = Vector3.zero;
                rb.gravityScale = 1;
                Vector3 jumpDirection = new Vector3 (0, jumpForceY, 0);
                transform.position += jumpDirection * speed * Time.deltaTime;
            }   
        }
        else
        {
            rb.gravityScale = 4;
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

    private IEnumerator JumpTime()
    {
        yield return new WaitForSeconds(0.3f);
        isJumping = false;
    }
}
