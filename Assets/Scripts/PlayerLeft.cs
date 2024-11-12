using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : MonoBehaviour
{
    private bool leftLimit;

    void Start()
    {

    }

    void Update()
    {

    }

    public bool LeftLimit
    {
        get { return leftLimit; }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            leftLimit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            leftLimit = false;
        }
    }
}
