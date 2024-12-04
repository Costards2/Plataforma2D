using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Verificar se o player atingiu o limite da direita ao se movimentar
public class DireitaPlayer : MonoBehaviour
{
    private bool limiteDireita;

    public bool LimiteDireita {
        get {return limiteDireita;}
    }

    private void OnTriggerStay2D(Collider2D colisao){
        if(colisao.gameObject.layer == 6){
            limiteDireita = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.layer == 6){
            limiteDireita = false;
        }
    }
}
