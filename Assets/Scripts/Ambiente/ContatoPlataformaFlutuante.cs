using UnityEngine;

public class ContatoPlataformaFlutuante : MonoBehaviour
{
    private SpriteRenderer corpo;
    private bool saiuDaColisao = false;
    private Animator animator;

    void Start()
    {
        corpo = GetComponentInParent<SpriteRenderer>();
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("PePlayer") && saiuDaColisao == false){
            saiuDaColisao = true;
            Rigidbody2D rigidbody2D = corpo.gameObject.AddComponent<Rigidbody2D>();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            animator.SetTrigger("death");
            Destroy(corpo.gameObject,0.25f);
        }
    }
}