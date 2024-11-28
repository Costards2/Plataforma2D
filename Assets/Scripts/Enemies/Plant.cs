using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float waitTime = 3f;
    private float currentTime;

    public GameObject projectile;

    private bool damage = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();    
        currentTime = Time.time + waitTime;
    }

    void Update()
    {
        if (damage) return;

        if (Time.time > currentTime)
        {
            currentTime = Time.time + waitTime;
            animator.SetTrigger("fire");
        }
    }

    public void Shoot()
    {
        GameObject createdProjectile = Instantiate(projectile);

        if (spriteRenderer.flipX)
        {
            createdProjectile.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.14f, transform.position.z);

            createdProjectile.GetComponent<PlantBullet>().ChangeDirection(Vector3.right);
        }
        else
        {
            createdProjectile.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.14f, transform.position.z);

            createdProjectile.GetComponent<PlantBullet>().ChangeDirection(Vector3.left);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10 && !damage)
        {
            PlayerManager.playerDamage.DamagePlayer();
            damage = true;
            animator.SetTrigger("hit");
        }
    }

    public void DestroyPlant()
    {
        Destroy(gameObject);
    }
}
