using UnityEngine;

public class DanoChefe : MonoBehaviour
{
    private ChefeMng chefeMng;
    private bool houveColisao = false;

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