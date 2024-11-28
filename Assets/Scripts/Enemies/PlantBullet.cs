using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    private bool collided = false;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void ChangeDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && !collided)
        {
            collided = true;
            PlayerManager.playerDamage.DamagePlayer();
        } 

        Destroy(gameObject);
    }
}
