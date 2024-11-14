using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayerBody : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool LeftOrRight { get { return spriteRenderer.flipX; } }

    public void LookRight()
    {
        spriteRenderer.flipX = false;
    }

    public void LookLeft()
    {
        spriteRenderer.flipX = true;
    }
}
