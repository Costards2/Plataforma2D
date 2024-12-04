using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaLamina : MonoBehaviour
{    
    public Vector3[] destinos;//Definir os destinos que a lamina vai ter que seguir
    public float velocidade;
    private int idProximoDestino; //Identificar qual o proximo destinos
    public float tempoDeEspera;
    private bool proximoDestino = false;//Auxiliar se devo ir para o proximo caminho
    private float proximoTempoDeEspera = 0; //Tempo para aguardar para seguir o caminho
    //private bool houveColisao = false;

    void Start()
    {
        transform.position = destinos[0];
        idProximoDestino = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o objeto pode ir para o proximo caminho
        if(proximoDestino == true){
            if(Time.time > proximoTempoDeEspera){
                idProximoDestino++;
                //Verificar se o id é o limite do vetor
                if(idProximoDestino == destinos.Length){
                    idProximoDestino = 0;
                }
                proximoDestino = false;
            }
        }
        else{
            //Movimentar o objeto

            float velocidadeMovimento = velocidade * Time.deltaTime;
            //Vou mover o objeto
            transform.position = Vector3.MoveTowards(transform.position,
            destinos[idProximoDestino],velocidadeMovimento);
            if(Vector3.Distance(transform.position,destinos[idProximoDestino])<0.001f){
                proximoTempoDeEspera = Time.time + tempoDeEspera;
                proximoDestino = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor){
        if(colisor.gameObject.tag.Equals("Player")){
            CanvasGameMng.Instance.MatarJogador();
        }
    }
}
