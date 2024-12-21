using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    private Animator animator;
    private bool coletouItem = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("Player") && coletouItem == false){
            coletouItem = true;
            animator.SetTrigger("coletarItem");
            AudioMng.Instance.PlayAudioFruta();
            CanvasGameMng.Instance.IncrementarItemColetavel();
        }
    }

    public void DestruirColetavel(){
        Destroy(gameObject);
    }
}