using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    private bool headLimit;

    public bool HeadLimit
    {
        get { return headLimit; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            headLimit = true;
            PlayerManager.playerMove.CancelJump();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            headLimit = false;
        }
    }
}
