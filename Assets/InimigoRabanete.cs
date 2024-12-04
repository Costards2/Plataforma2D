using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoRabanete : MonoBehaviour
{
    private SpriteRenderer corpo;
    private Animator animator;
    public float velocidade;
    private bool estaParado = false;
    private bool houveColisao = false;
    private string animacaoAtual;
    private float tempoDeEspera = 3f;
    private float proximoTempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animacaoAtual = "run";
    }

    // Update is called once per frame
    void Update()
    {
        //Logica para movimentar o inimigo e fazer a virada
        //Verificar se o inimigo está parado
        if(estaParado == true){
            //Verificar se está no tempo de virada
            if(Time.time > proximoTempo){
                VirarInimigo();
            }
            return;
        }
        transform.Translate(Vector3.left * Time.deltaTime * velocidade);
    }

    private void OnTriggerExit2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            animator.SetTrigger("idle");
            animacaoAtual = "idle";
            proximoTempo = Time.time + tempoDeEspera;
            estaParado = true;
        }
    }

    private void VirarInimigo(){
        //Inverter a velocidade atual do inimigo
        velocidade *=-1;
        corpo.flipX = !corpo.flipX;
        estaParado = false;
        animator.SetTrigger("run");
        animacaoAtual = "run";
        houveColisao = false;
    }

    private void OnTriggerEnter2D(Collider2D colisor){
        if(colisor.gameObject.layer == 10 && houveColisao == false){
            HitInimigo();
        }
    }

    private void OnTriggerStay2D(Collider2D colisor){
        if(colisor.gameObject.layer == 10 && houveColisao == false){
            HitInimigo();
        }
    }

    private void HitInimigo(){
        PlayerMng.playerDano.DanoAoPlayer();
        animator.SetTrigger("hit");
        houveColisao = true;
    }

    public void AtivaAnimacaoAposDano(){
        animator.SetTrigger(animacaoAtual);
        houveColisao = false;
    }
}
