using UnityEngine;

public class CanvasLoadingMng : MonoBehaviour
{
    public static CanvasLoadingMng Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public GameObject pnlLoading;

    public void ExibirPainelLoading(){
        pnlLoading.SetActive(true);
    }

    public void OcultarPainelLoading(){
        pnlLoading.SetActive(false);
    }
}