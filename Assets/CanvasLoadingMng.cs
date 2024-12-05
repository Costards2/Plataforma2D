using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoadingMng : MonoBehaviour
{
    public static CanvasLoadingMng instance; //{ get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject pnlLoading;

    public void ExibirPainelLoading()
    {
        pnlLoading.SetActive(true);
    }

    public void OcultarPainelLoading()
    {
        pnlLoading.SetActive(false);
    }
}
