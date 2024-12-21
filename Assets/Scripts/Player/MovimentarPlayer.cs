using System.Collections;
using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    public float velocidade; 
    private bool estaPulando = false;
    private bool puloDuplo = false;
    public float forcaDoPuloY = 1.5f;
    public float forcaDoPuloX;
    private bool habilitaPulo = false;
    private Coroutine coroutinePulo;

    void Update()
    {
        if(PlayerMng.Instance.movimentacaoHabilitada == false) return;
        Movimentar();
        Pular(); 
        PularDaParede();               
    }

    private void PularDaParede(){
        if(PlayerMng.pePlayer.EstaNoChao == false &&  PlayerMng.cabecaPlayer.LimiteDaCabeca == false && (PlayerMng.direitaPlayer.LimiteDireita == true || PlayerMng.esquerdaPlayer.LimiteEsquerda == true)){
            PlayerMng.animacaoPlayer.PlayWallSlider();

            if(Input.GetButtonDown("Jump")){
                forcaDoPuloX = PlayerMng.flipCorpoPlayer.VisaoEsquerdaOuDireita == true ?
                forcaDoPuloY : forcaDoPuloY *-1;
                PlayerMng.animacaoPlayer.PlayJump();
                AudioMng.Instance.PlayAudioPular();
                puloDuplo = true;
                estaPulando = true;
                AtivarTempoPulo();
            } 
        }
    }

    private void Pular(){
        if(Input.GetButtonDown("Jump")){

            if(habilitaPulo == true){
                PlayerMng.animacaoPlayer.PlayJump();
                AudioMng.Instance.PlayAudioPular();
                habilitaPulo = false;
                estaPulando = true;
                puloDuplo = true;
                AtivarTempoPulo();
            }
            else{
                if(puloDuplo == true){
                    PlayerMng.animacaoPlayer.PlayDoubleJump();
                    AudioMng.Instance.PlayAudioPular();
                    estaPulando = true;
                    puloDuplo = false;
                    AtivarTempoPulo();
                }
            }
        }

        if(estaPulando == true){

            if(PlayerMng.cabecaPlayer.LimiteDaCabeca == false){
                PlayerMng.rigidBody2D.velocity = Vector3.zero;
                PlayerMng.rigidBody2D.gravityScale = 0;
                Vector3 direcaoPulo = new Vector3(forcaDoPuloX,forcaDoPuloY,0);
                transform.position += direcaoPulo * Time.deltaTime * velocidade;
            }
        }
        else{
            PlayerMng.rigidBody2D.gravityScale = 4;
        }
    }

    public void AtivarTempoPulo(){
        if(coroutinePulo != null){
            StopCoroutine(coroutinePulo);
        }
        coroutinePulo = StartCoroutine(TempoPulo());
    }

    private IEnumerator TempoPulo(){
        yield return new WaitForSeconds(0.3f);
        forcaDoPuloX = 0;
        estaPulando = false;
    }

    private void Movimentar(){
        float eixoX = Input.GetAxis("Horizontal");

        if(eixoX>0 && PlayerMng.direitaPlayer.LimiteDireita == true) { eixoX = 0;}
        else if (eixoX<0 && PlayerMng.esquerdaPlayer.LimiteEsquerda == true) {eixoX = 0;}

        if(eixoX > 0){
            PlayerMng.flipCorpoPlayer.OlharDireita();
        }
        else if(eixoX < 0){
            PlayerMng.flipCorpoPlayer.OlharEsquerda();
        }

        if(PlayerMng.pePlayer.EstaNoChao == true){
            if(eixoX != 0){
                PlayerMng.animacaoPlayer.PlayRun();
            }
            else{
                PlayerMng.animacaoPlayer.PlayIdle();
            }
        }
        else{
            PlayerMng.animacaoPlayer.PlayFall();
        }

        Vector3 direcaoMovimento = new Vector3(eixoX,0,0);
        transform.position += direcaoMovimento * velocidade * Time.deltaTime;
    }

    public void HabilitaPulo(){
        habilitaPulo = true;
    }

    public void CancelarPulo(){
        if(coroutinePulo != null){
            StopCoroutine(coroutinePulo);
        }
        forcaDoPuloX = 0;
        estaPulando = false;
    }
}