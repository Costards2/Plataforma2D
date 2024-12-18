using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoChefe : MonoBehaviour
{
    private ChefeMng chefeMng;
    private bool houveColisao = false;
    // Start is called before the first frame update
    void Start()
    {
        chefeMng = GetComponentInParent<ChefeMng>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "PePlayer" && houveColisao == false){
            houveColisao = true;
            PlayerMng.Instance.ExpelirPlayer();
            chefeMng.DecrementarVidaChefe();
            Invoke("PermitirColisao",0.3f);
        }
    }

    private void PermitirColisao(){
        houveColisao = false;
    }
}
