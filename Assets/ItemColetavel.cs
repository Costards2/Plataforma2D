using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    private Animator animator;
    private bool coletouItem = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("Player") && coletouItem == false){
            coletouItem = true;
            animator.SetTrigger("coletarItem");

            //Incrementar a coleta na UI
            CanvasGameMng.Instance.IncrementarItemColetavel();
        }
    }

    public void DestruirColetavel(){
        Destroy(gameObject);
    }
}
