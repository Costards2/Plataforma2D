using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private bool collisionHappend = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10 && collisionHappend == false)
        {
            collisionHappend = true;
            PlayerManager.playerDamage.DamagePlayer();
            StartCoroutine(AllowCollision());
        }

        IEnumerator AllowCollision()
        {
            yield return new WaitForSeconds(0.3f);
            collisionHappend = false;   
        }
    }
}
