using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    //Variável de velocidade de movimentação
    public float velocidade; 
    private bool estaPulando = false;
    private bool puloDuplo = false;
    public float forcaDoPuloY = 1.5f;
    public float forcaDoPuloX;
    private bool habilitaPulo = false;

    private Coroutine coroutinePulo;

    // Update is called once per frame
    void Update()
    {
        if(PlayerMng.Instance.movimentacaoHabilitada == false) return;
        Movimentar();
        Pular(); 
        PularDaParede();               
    }

    private void PularDaParede(){
        //Verificar se o jogador não está no chão e se ele está na parede
        if(PlayerMng.pePlayer.EstaNoChao == false && 
        PlayerMng.cabecaPlayer.LimiteDaCabeca == false &&
        (PlayerMng.direitaPlayer.LimiteDireita == true ||
        PlayerMng.esquerdaPlayer.LimiteEsquerda == true)){
            //Ativar animação na parede
            PlayerMng.animacaoPlayer.PlayWallSlider();
            //Verificar se o jogador que pular da parede
            if(Input.GetButtonDown("Jump")){
                forcaDoPuloX = PlayerMng.flipCorpoPlayer.VisaoEsquerdaOuDireita == true ?
                forcaDoPuloY : forcaDoPuloY *-1;
                PlayerMng.animacaoPlayer.PlayJump();
                puloDuplo = true;
                estaPulando = true;
                AtivarTempoPulo();
            } 
        }
    }

    //Método para o player pular
    private void Pular(){
        //Verificar se o jogador clicou na tecla para pular
        if(Input.GetButtonDown("Jump")){
            //Verificar se o jogador está apto a pular
            if(habilitaPulo == true){
                //Ativo o Pulo
                PlayerMng.animacaoPlayer.PlayJump(); //Ativar a animação do pulo
                habilitaPulo = false;
                estaPulando = true;//Definir um estado de pulo
                puloDuplo = true;//Definir um estado de pulo duplo
                AtivarTempoPulo();//Ativar o tempo de pulo
            }
            else{
                //Verificar se eu posso fazer o pulo duplo
                if(puloDuplo == true){
                    PlayerMng.animacaoPlayer.PlayDoubleJump();//Ativar a animação do pulo duplo
                    estaPulando = true;//Definir o estado de pulo
                    puloDuplo = false;//Definir o estado do pulo duplo 
                    AtivarTempoPulo();//Ativar o tempo de pulo
                }

            }
        }

        //Verificar se está habilitado o jogador a pular
        if(estaPulando == true){
            //Verificar se a cabeça do jogador está livre
            if(PlayerMng.cabecaPlayer.LimiteDaCabeca == false){
                //Fazer o jogador subir para simular o pulo
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
            StopCoroutine(coroutinePulo); //Parar a execução da rotina
        }
        coroutinePulo = StartCoroutine(TempoPulo());
    }

    //Método para inverter o valor do "estaPulando" através de um tempo
    private IEnumerator TempoPulo(){
        yield return new WaitForSeconds(0.3f);
        forcaDoPuloX = 0;
        estaPulando = false;
    }

    //Método para movimentar o player
    private void Movimentar(){
        //Movimentar o Player
        float eixoX = Input.GetAxis("Horizontal");
        //Verificar se chegou na extremidade da direita ou esquerda
        if(eixoX>0 && PlayerMng.direitaPlayer.LimiteDireita == true) { eixoX = 0;}
        else if (eixoX<0 && PlayerMng.esquerdaPlayer.LimiteEsquerda == true) {eixoX = 0;}

        //Verificar qual a lado olhar
        if(eixoX > 0){
            PlayerMng.flipCorpoPlayer.OlharDireita();
        }
        else if(eixoX < 0){
            PlayerMng.flipCorpoPlayer.OlharEsquerda();
        }

        //Verificar se o player está no chao
        if(PlayerMng.pePlayer.EstaNoChao == true){
            //Verificar se o player está parado ou movendo
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

        //Movimentar o player
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
