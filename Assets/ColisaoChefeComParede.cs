using System.Collections;
using System.Collections.Generic;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 && houveColisao == false)
        {
            houveColisao = true;
            movimentarChefe.FlipSprite();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            houveColisao = false;
        }
    }
}
