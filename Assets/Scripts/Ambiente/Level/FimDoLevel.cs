using UnityEngine;

public class FimDoLevel : MonoBehaviour
{
    private Animator animator;
    private bool fimDoLevel = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && fimDoLevel == false){
            fimDoLevel = true;
            animator.SetTrigger("fimDoJogo");
            AudioMng.Instance.PlayAudioItemFinal();
            CanvasGameMng.Instance.FimDoJogo();
        }
    }
}
