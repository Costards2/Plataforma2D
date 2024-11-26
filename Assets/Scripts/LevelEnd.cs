using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private Animator animator;

    public bool levelEnd = false;

    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && levelEnd == false)
        {
            levelEnd = true;
            animator.SetTrigger("gameEnd");
            CanvasManager.instance.EndGame();
        }
    }
}
