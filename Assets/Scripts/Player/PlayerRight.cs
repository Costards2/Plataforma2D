using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRight : MonoBehaviour
{
    private bool rightLimit;

    public bool RightLimit
    {
        get { return rightLimit;}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            rightLimit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rightLimit = false;
        }
    }
}
