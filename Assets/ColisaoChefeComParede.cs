using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColisaoChefeComParede : MonoBehaviour
{
    private MovimentarChefe movimentarChefe;
    private bool houveColisao = false;
    // Start is called before the first frame update
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
