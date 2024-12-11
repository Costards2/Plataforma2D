using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenuMng : MonoBehaviour
{
    public static CanvasMenuMng Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public TextMeshProUGUI[] txtItensColetadosPorNiveis;
    public GameObject[] cadeados;
    public GameObject[] qtdsItemLevel;
    public GameObject[] medalhas;
    public Sprite[] sptsMedalhas;
    // Start is called before the first frame update
    void Start()
    {
        ConfigurarPainelNivel();
        CanvasLoadingMng.Instance.OcultarPainelLoading();
    }

    private void ConfigurarPainelNivel(){
        //Configurar os textos com quantidade de frutas
        for(int i = 1; i < txtItensColetadosPorNiveis.Length;i++){
            txtItensColetadosPorNiveis[i].text = "x" + DBMng.BuscarQtdFrutasLevel(i).ToString();
        }

        //Configurar os cadeados e as qts de itens do level
        for(int i = 2; i < cadeados.Length;i++){
            bool estaHabilitado = DBMng.BuscarLevelHabilitado(i) == 1 ? true : false;
            cadeados[i].SetActive(!estaHabilitado);
            qtdsItemLevel[i].SetActive(estaHabilitado);
        }

        //Configurar as medalhas do level
        for(int i = 1; i < medalhas.Length;i++){
            int medalhaDoLevel = DBMng.BuscarMedalhaLevel(i);
            if(medalhaDoLevel == 0){
                medalhas[i].SetActive(false);
            }
            else{
                medalhas[i].GetComponent<Image>().sprite = sptsMedalhas[medalhaDoLevel];
            }
        }
    }

    //Level 1 terá um método aparte para iniciar a fase
    public void IniciarLevel1(){
        CanvasLoadingMng.Instance.ExibirPainelLoading();
        SceneManager.LoadScene(1);
    }

    //Carregar os demais leveis do jogo
    public void IniciarLevel(int idLevel){
        //Só deve funcionar se o cadeado estiver oculto
        if(cadeados[idLevel].activeSelf == false){
            CanvasLoadingMng.Instance.ExibirPainelLoading();
            SceneManager.LoadScene(idLevel);
        }
    }
}
