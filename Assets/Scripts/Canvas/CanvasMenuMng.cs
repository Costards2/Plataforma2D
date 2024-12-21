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
    public GameObject[] paineis;
    public Slider sldVFX;
    public Slider sldMusica;
    private Volume volume;

    void Start()
    {
        ConfigurarPainelNivel();
        ConfigurarPainelConfiguracoes();
        AudioMng.Instance.PlayAudioMenu();
        CanvasLoadingMng.Instance.OcultarPainelLoading();
    }

    private void ConfigurarPainelConfiguracoes(){
        volume = DBMng.ObterVolumes();
        sldVFX.value = volume.vfx;
        sldMusica.value = volume.musica;
        AudioMng.Instance.MudarVolume(volume);
    }

    private void ConfigurarPainelNivel(){
        for(int i = 1; i < txtItensColetadosPorNiveis.Length;i++){
            txtItensColetadosPorNiveis[i].text = "x" + DBMng.BuscarQtdFrutasLevel(i).ToString();
        }

        for(int i = 2; i < cadeados.Length;i++){
            bool estaHabilitado = DBMng.BuscarLevelHabilitado(i) == 1 ? true : false;
            cadeados[i].SetActive(!estaHabilitado);
            qtdsItemLevel[i].SetActive(estaHabilitado);
        }

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

    public void IniciarLevel1(){
        AudioMng.Instance.PlayAudioClick();
        CanvasLoadingMng.Instance.ExibirPainelLoading();
        SceneManager.LoadScene(1);
    }

    public void IniciarLevel(int idLevel){
        if(cadeados[idLevel].activeSelf == false){
            AudioMng.Instance.PlayAudioClick();
            CanvasLoadingMng.Instance.ExibirPainelLoading();
            SceneManager.LoadScene(idLevel);
        }
    }

    public void ExibirPainel(int id){
        AudioMng.Instance.PlayAudioClick();
        foreach(var painel in paineis){
            painel.SetActive(false);
        }
        paineis[id].SetActive(true);
    }

    public void FecharJogo(){
        Application.Quit();
    }

    public void MudarVolumeVFX(){
        DBMng.SalvarVolume(sldVFX.value, volume.musica);
        AtualizarVolumes();
    }

    public void MudarVolumeMusica(){
        DBMng.SalvarVolume(volume.vfx, sldMusica.value);
        AtualizarVolumes();
    }

    public void AtualizarVolumes(){
        volume = DBMng.ObterVolumes();
        AudioMng.Instance.MudarVolume(volume);
    }
}