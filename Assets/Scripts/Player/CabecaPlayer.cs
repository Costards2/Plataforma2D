using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabecaPlayer : MonoBehaviour
{
    private bool limiteDaCabeca;

    public bool LimiteDaCabeca{
        get {return limiteDaCabeca;}
    }
    
    private void OnTriggerEnter2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            limiteDaCabeca = true;
            PlayerMng.movimentarPlayer.CancelarPulo();
        }
    }

    private void OnTriggerExit2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            limiteDaCabeca = false;
        }
    }
}
