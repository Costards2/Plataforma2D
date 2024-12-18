using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ChefeMng : MonoBehaviour
{
    private Animator animator;
    private List<BoxCollider2D> colisores;
    private int vidaChefe = 4;
    public GameObject itemFinal;
    public bool estaMovendo = false;
    // Start is called before the first frame update
    void Start()
    {
        itemFinal.SetActive(false);
        animator = GetComponent<Animator>();
        colisores = GetComponentsInChildren<BoxCollider2D>().ToList();
        colisores.Add(GetComponent<BoxCollider2D>());
    }

    public void DecrementarVidaChefe(){
        vidaChefe--;
        //Verificar se a vida chegou a 0
        if(vidaChefe == 0){
            estaMovendo = false;
            
            //Destruir todos os colisores
            foreach(var colisor in colisores){
                Destroy(colisor);
            }

            animator.SetTrigger("death");
        }
        else{
            animator.SetTrigger("hit");
        }
    }

    public void AtivarItemFinal(){
        itemFinal.SetActive(true);
        Destroy(gameObject);
    }

    public void HabilitarMovimentacao(){
        estaMovendo = true;
        animator.SetBool("run", true);
        animator.SetBool("idle", false);
    }
}
