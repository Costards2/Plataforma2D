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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PePlayer" && houveColisao == false)
        {
            houveColisao = true;
            PlayerMng.Instance.ExpelirPlayer();
            chefeMng.DecrementaVidaChefe();
            StartCoroutine(PermitirColisao());
        }
    }

    private IEnumerator PermitirColisao()
    {
        yield return new WaitForSeconds(0.3f);
        houveColisao = false;
    }
}
