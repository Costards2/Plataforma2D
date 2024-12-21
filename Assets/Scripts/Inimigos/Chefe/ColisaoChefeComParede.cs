using UnityEngine;

public class ColisaoChefeComParede : MonoBehaviour
{
    private MovimentarChefe movimentarChefe;
    private bool houveColisao = false;

    void Start()
    {
        movimentarChefe = GetComponentInParent<MovimentarChefe>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 6 && houveColisao == false){
            houveColisao = true;
            movimentarChefe.FlipCorpo();
        }
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.layer == 6){
            houveColisao = false;
        }
    }
}
