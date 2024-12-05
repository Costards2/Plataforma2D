using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenuMng : MonoBehaviour
{
    public static CanvasMenuMng instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public TextMeshProUGUI[] txtItemsColetadosPorNiveis;
    public GameObject[] cadeados;
    public GameObject[] qtdItemLevel;
    public GameObject[] medalhas;
    public Sprite[] sptsMedalhas;

    // Start is called before the first frame update
    void Start()
    {
        ConfigurarPainelNivel();
        CanvasLoadingMng.instance.OcultarPainelLoading();
    }

    private void ConfigurarPainelNivel()
    {
        // Configurar txt das frutas
        for (int i = 1; i < txtItemsColetadosPorNiveis.Length; i++) 
        {
            txtItemsColetadosPorNiveis[i].text = "X" +DBMng.BuscarQtdFrutasLevel(i).ToString();
        }

        // Configurar os cadeados e Items level
        for (int i = 2; i < cadeados.Length; i++)
        {
            bool estaHabilitado = DBMng.BuscarLevelHabilitado(i) == 1 ? true : false;
            cadeados[i].SetActive(!estaHabilitado);

            qtdItemLevel[i].SetActive(estaHabilitado);
        }

        // Configurar as medalhas do level
        for (int i = 1; i < medalhas.Length; i++)
        {
            int medalhaLvl = DBMng.BuscarMedalhaLevel(i);
            if (medalhaLvl == 0)
            {
                medalhas[i].SetActive(false);
            }
            else
            {
                medalhas[i].GetComponent<Image>().sprite = sptsMedalhas[medalhaLvl];
            }
        }
    }

    public void IniciarLevel1()
    {
        CanvasLoadingMng.instance.ExibirPainelLoading();
        SceneManager.LoadScene(1);
    }

    public void IniciarLevel(int idLevel)
    {
        if (cadeados[idLevel].activeSelf == false)
        {
            CanvasLoadingMng.instance.ExibirPainelLoading();
            SceneManager.LoadScene(idLevel);
        }
    }
}
