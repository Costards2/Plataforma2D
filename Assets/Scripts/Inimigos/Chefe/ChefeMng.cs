using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChefeMng : MonoBehaviour
{
    private Animator animator;
    private List<BoxCollider2D> colisores;
    private int vidaChefe = 4;
    public GameObject itemFinal;
    public bool estaMovendo = false;

    void Start()
    {
        itemFinal.SetActive(false);
        animator = GetComponent<Animator>();
        colisores = GetComponentsInChildren<BoxCollider2D>().ToList();
        colisores.Add(GetComponent<BoxCollider2D>());
    }

    public void DecrementarVidaChefe(){
        vidaChefe--;
        
        if(vidaChefe == 0){
            estaMovendo = false;

            foreach(var colisor in colisores){
                Destroy(colisor);
            }

            animator.SetTrigger("death");
            AudioMng.Instance.PlayAudioMorteChefe();
        }
        else{
            animator.SetTrigger("hit");
            AudioMng.Instance.PlayAudioDanoInimigo();
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