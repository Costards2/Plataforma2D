using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquerdaPlayer : MonoBehaviour
{
    private bool limiteEsquerda;

    public bool LimiteEsquerda {
        get {return limiteEsquerda;}
    }

    private void OnTriggerStay2D(Collider2D colisao){
        if(colisao.gameObject.layer == 6){
            limiteEsquerda = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.layer == 6){
            limiteEsquerda = false;
        }
    }
}
