using UnityEngine;

public class PePlayer : MonoBehaviour
{
    private bool estaNoChao;

    public bool EstaNoChao{
        get{return estaNoChao;}
    }
    
    private void OnTriggerStay2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            estaNoChao = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            estaNoChao = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            PlayerMng.movimentarPlayer.HabilitaPulo();
        }
    }
}