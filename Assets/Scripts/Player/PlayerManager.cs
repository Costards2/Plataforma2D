using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public static FlipPlayerBody flipPlayerBody;
    public static PlayerAnimation playerAnimation;
    public static PlayerHead playerHead;
    public static PlayerFeet playerFeet;
    public static PlayerRight playerRight;
    public static PlayerLeft playerLeft;
    public static PlayerMove playerMove;
    public static PlayerDamage playerDamage;
    public static Rigidbody2D rigidbody2D;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            flipPlayerBody = GetComponentInChildren<FlipPlayerBody>();
            playerAnimation = GetComponentInChildren<PlayerAnimation>();
            playerHead = GetComponentInChildren<PlayerHead>();
            playerFeet = GetComponentInChildren<PlayerFeet>();
            playerRight = GetComponentInChildren<PlayerRight>();
            playerLeft = GetComponentInChildren<PlayerLeft>();

            playerMove = GetComponent<PlayerMove>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            playerDamage = GetComponent<PlayerDamage>();

            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetPhysicsVelociy()
    {
        rigidbody2D.velocity = Vector3.zero;
    }

    public void ThrowPlayer(int x, int y)
    {
        rigidbody2D.AddForce(new Vector2(x, y));
    }
}