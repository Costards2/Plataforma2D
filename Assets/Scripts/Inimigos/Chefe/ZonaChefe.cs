using UnityEngine;

public class ZonaChefe : MonoBehaviour
{
    private ChefeMng chefeMng;

    void Start()
    {
        chefeMng = FindObjectOfType<ChefeMng>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10){
            chefeMng.HabilitarMovimentacao();
            AudioMng.Instance.PlayAudioChefe();
            Destroy(gameObject);
        }
    }
}