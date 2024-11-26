using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private Animator animator;

    private bool collectedItem = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player") && !collectedItem)
        {
            collectedItem = true;
            animator.SetTrigger("collectItem");

            CanvasManager.instance.AddCollectedItem();
        }
    }

    private void DestroyCollectable()
    {
        Destroy(gameObject);
    }
}
