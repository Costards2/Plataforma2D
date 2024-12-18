using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarChefe : MonoBehaviour
{
    private ChefeMng chefeMng;
    private SpriteRenderer corpo;
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        chefeMng = GetComponent<ChefeMng>();
        corpo = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o chefe pode ou não se mover
        if(chefeMng.estaMovendo == false) return;
        //Movimentar para esquerda ou direita
        if(corpo.flipX == false){
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }
        else{
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }
    }

    public void FlipCorpo(){
        corpo.flipX = !corpo.flipX;
    }
}
