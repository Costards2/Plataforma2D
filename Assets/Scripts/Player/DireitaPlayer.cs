using UnityEngine;

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