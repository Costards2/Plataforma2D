using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeEspinhos : MonoBehaviour
{
    public float velocidade = 100;
    public bool rotacaoConstante = false;

    void Update()
    {
        transform.eulerAngles += Vector3.back * velocidade * Time.deltaTime;
        if(transform.eulerAngles.z <=270 && transform.eulerAngles.z >=90 &&
        rotacaoConstante == false){
            velocidade*=-1;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor){
        if(colisor.gameObject.tag == "Player"){
            CanvasGameMng.Instance.MatarJogador();
        }
    }
}
