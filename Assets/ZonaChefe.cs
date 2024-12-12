using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaChefe : MonoBehaviour
{
    private ChefeMng chefeMng;

    // Start is called before the first frame update
    void Start()
    {
        chefeMng = FindObjectOfType<ChefeMng>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) 
        {
            chefeMng.HabilitarMovimentacao();
            Destroy(gameObject);
        }
    }
}
