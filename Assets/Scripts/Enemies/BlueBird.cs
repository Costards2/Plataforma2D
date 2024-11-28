using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : MonoBehaviour
{
    private SpriteRenderer sptBody;
    private Animator animator;
    public float moveDistance;
    public float moveSpeed;

    private Vector3 initialPosition, finalPosition, targetPosition;

    private bool isDead = false;

    void Start()
    {
        sptBody = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        finalPosition = transform.position + new Vector3(moveDistance, 0, 0);
        targetPosition = finalPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            if(!sptBody.flipX)
            {
                targetPosition = initialPosition;
            }
            else
            {
                targetPosition = finalPosition;
            }
            
            sptBody.flipX = !sptBody.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag.Equals("PlayerFeet") && !isDead))
        {
            PlayerManager.instance.ExpelPlayer();
            animator.SetTrigger("death");
            isDead = true;
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
