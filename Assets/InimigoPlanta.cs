using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class InimigoPlanta : MonoBehaviour
{
    private SpriteRenderer corpo;
    private Animator animator;
    public float tempoDeEspera = 3f;
    private float tempoAgora;
    public GameObject projetil;
    private bool teveDano = false;
    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        tempoAgora = Time.time + tempoDeEspera;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se a planta sofreu dano
        if(teveDano == true) return;
        //Verificar se é hora de atirar
        if(Time.time > tempoAgora){
            //Atualizar o tempo de agora
            tempoAgora = Time.time + tempoDeEspera;
            animator.SetTrigger("fire");
        }
    }

    public void AtirarProjetil(){
        //Criar/instanciar o projetil.
        GameObject projetilCriado = Instantiate(projetil);
        //Verificar para qual lado a plata está olhando
        if(corpo.flipX == true){
            //Projetar o projetil para a direita
            projetilCriado.transform.position = new Vector3(transform.position.x + 0.5f,
            transform.position.y + 0.14f,0);
            projetilCriado.GetComponent<ProjetilPlanta>().MudarDirecao(Vector3.right);
        }
        else{
            //Projetar o projetil para a esquerda
            projetilCriado.transform.position = new Vector3(transform.position.x - 0.5f,
            transform.position.y + 0.14f,0);
            projetilCriado.GetComponent<ProjetilPlanta>().MudarDirecao(Vector3.left);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && teveDano == false){
            PlayerMng.playerDano.DanoAoPlayer();
            teveDano = true;
            animator.SetTrigger("hit");
        }
    }

    public void DestruirPlanta(){
        Destroy(gameObject);
    }
}
