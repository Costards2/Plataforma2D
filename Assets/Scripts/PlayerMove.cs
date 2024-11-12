using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private PlayerRight playerRight;
    private PlayerLeft playerLeft;
    private FlipPlayerBody flipPlayerBody;

    void Start()
    {
        playerRight = GetComponentInChildren<PlayerRight>();
        playerLeft = GetComponentInChildren<PlayerLeft>();
        flipPlayerBody = GetComponentInChildren<FlipPlayerBody>();
    }

    void Update()
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

        Vector3 moveDirection = new Vector3(xInput, 0, 0);
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
