using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChefeMng : MonoBehaviour
{
    private Animator animator;
    private List<BoxCollider2D> colliders = new List<BoxCollider2D>();
    private int vidaChefe = 4;

    public GameObject itemFinal;
    public bool estaMovendo = false;

    // Start is called before the first frame update
    void Start()
    {
        itemFinal.SetActive(false);
        animator = GetComponent<Animator>();
        colliders = GetComponentsInChildren<BoxCollider2D>().ToList();
        colliders.Add(GetComponent<BoxCollider2D>());
    }

   public void DecrementaVidaChefe() 
   {
        vidaChefe--;

        if (vidaChefe == 0)
        {
            estaMovendo = false;

            foreach (var collider in colliders)
            {
                Destroy(collider);
            }

            animator.SetTrigger("death");
        }
        else 
        {
            animator.SetTrigger("hit");
        }
        
   }

    public void AtivarItemFinal()
    {
        itemFinal.SetActive(true);
        Destroy(gameObject);
    }

    public void HabilitarMovimentacao()
    {
        estaMovendo = true;
        animator.SetBool("run", true);
        animator.SetBool("idle", false);
    }
}
