using UnityEngine;

public class ArmadilhaLamina : MonoBehaviour
{    
    public Vector3[] destinos;
    public float velocidade;
    private int idProximoDestino;
    public float tempoDeEspera;
    private bool proximoDestino = false;
    private float proximoTempoDeEspera = 0;

    void Start()
    {
        transform.position = destinos[0];
        idProximoDestino = 1;
    }

    void Update()
    {
        if(proximoDestino == true){
            if(Time.time > proximoTempoDeEspera){
                idProximoDestino++;
                if(idProximoDestino == destinos.Length){
                    idProximoDestino = 0;
                }
                proximoDestino = false;
            }
        }
        else{
            float velocidadeMovimento = velocidade * Time.deltaTime;
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