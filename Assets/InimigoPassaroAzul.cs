using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPassaroAzul : MonoBehaviour
{
    private SpriteRenderer sptCorpo;
    public float distanciaDeMovimento;
    public float velocidade;
    private Vector3 posicaoInicial;
    private Vector3 posicaoFinal;
    private Vector3 posicaoAlvo;
    private bool estaMorto = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sptCorpo = GetComponent<SpriteRenderer>();
        posicaoInicial = transform.position;
        posicaoFinal = transform.position + new Vector3(distanciaDeMovimento,0,0);
        posicaoAlvo = posicaoFinal;
    }

    // Update is called once per frame
    void Update()
    {
        //Mover o inimigo até a posição alvo
        transform.position = Vector3.MoveTowards(
            transform.position,
            posicaoAlvo,
            velocidade * Time.deltaTime);
        //Verificar se o inimigo chegou na posição do alvo
        if(Vector3.Distance(transform.position, posicaoAlvo)<0.001f){
            //Inverter corpo do inimigo e mudar a posiçao do alvo
            if(sptCorpo.flipX == false){
                posicaoAlvo = posicaoInicial;
            }
            else{
                posicaoAlvo = posicaoFinal;
            }
            sptCorpo.flipX = !sptCorpo.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "PePlayer" && estaMorto == false){
            PlayerMng.Instance.ExpelirPlayer();
            animator.SetTrigger("morte");
            estaMorto = true;
        }
    }

    public void DestruirInimigo(){
        Destroy(gameObject);
    }
}
