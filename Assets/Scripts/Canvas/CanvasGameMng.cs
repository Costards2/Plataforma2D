using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public Image imgBarraDeVida;
    public TextMeshProUGUI txtTotalItensColetados;
    public TextMeshProUGUI txtTempoDeJogo;
    public Sprite[] sptsBarraDeVida;
    private int vidas;
    public bool jogadorMorreu = false;
    private int totalItensColetados = 0;
    public float tempoDoJogo;
    public bool fimDoTempo;
    public GameObject painelFimDoJogo;
    public TextMeshProUGUI txtTotalFrutasFimDoJogo; 
    public Image imgMedalhaDoLevel;
    public Sprite[] sptsMedalhas;
    private int idLevel;
    private int idMedalhaLevel;
    private double qtdItensColetaveis;

    void Start()
    {
        vidas = sptsBarraDeVida.Length -1;
        txtTotalItensColetados.text = $"x{totalItensColetados}";
        txtTempoDeJogo.text = ((int)tempoDoJogo).ToString();
        fimDoTempo = false;
        painelFimDoJogo.SetActive(false);
        idLevel = SceneManager.GetActiveScene().buildIndex;
        qtdItensColetaveis = FindObjectsOfType<ItemColetavel>().Length;

        Volume volume = DBMng.ObterVolumes();
        AudioMng.Instance.MudarVolume(volume);
        AudioMng.Instance.PlayAudioGame();

        CanvasLoadingMng.Instance.OcultarPainelLoading();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            VoltarParaMenu();
        }
        ContarTempo();
    }

    public void DecrementarVidaJogador(){
        vidas--;
        if(vidas < 0){
            MatarJogador();
        }
        else{
            imgBarraDeVida.sprite = sptsBarraDeVida[vidas];
        }
    }

    public void MatarJogador(){
        jogadorMorreu = true;
        vidas = 0;
        imgBarraDeVida.sprite = sptsBarraDeVida[vidas];
        AudioMng.Instance.PlayAudioMorte();
        PlayerMng.animacaoPlayer.PlayerDeath();
        PlayerMng.Instance.DesabilitarMovimentacao();
        PlayerMng.Instance.RemoverSimulacaoDaFisica();
        StartCoroutine(ReiniciarLevel());
    }

    IEnumerator ReiniciarLevel(){
        yield return new WaitForSeconds(3f);
        ReiniciarLevelAtual();
    }    

    public void IncrementarItemColetavel(){
        totalItensColetados++;
        txtTotalItensColetados.text = $"x{totalItensColetados}";
    }

    public void ContarTempo(){
        if(fimDoTempo == true) return;

        tempoDoJogo -= Time.deltaTime;
        if(tempoDoJogo <= 0){
            fimDoTempo = true;
            vidas = 0;
            DecrementarVidaJogador();
        }
        else{
            txtTempoDeJogo.text = ((int)tempoDoJogo).ToString();
        }
    }

    public void FimDoJogo(){
        fimDoTempo = true;
        PlayerMng.Instance.CongelarPlayer();
        SalvarDadosDoLevel();
        StartCoroutine(ExibirTelaFinalDoLevel());
    }

    private void SalvarDadosDoLevel(){
        int itensSalvosDoLevel = DBMng.BuscarQtdFrutasLevel(idLevel);
        DefinirMedalhaDoLevel();
        if(totalItensColetados > itensSalvosDoLevel){
            DBMng.SalvarDadosLevel(idLevel,totalItensColetados,idMedalhaLevel);
        }
    }
    private void DefinirMedalhaDoLevel(){
        double porcentagem = ((double)totalItensColetados/qtdItensColetaveis) * 100;
        if(porcentagem < 50){
            idMedalhaLevel = 1;
        }
        else if(porcentagem >=50 && porcentagem < 100){
            idMedalhaLevel = 2;
        }
        else{
            idMedalhaLevel = 3;
        }
        imgMedalhaDoLevel.sprite = sptsMedalhas[idMedalhaLevel];
    }

    IEnumerator ExibirTelaFinalDoLevel(){
        yield return new WaitForSeconds(3f);
        painelFimDoJogo.SetActive(true);
        int contagem = 0;
        while(contagem < totalItensColetados){
            contagem++;
            txtTotalFrutasFimDoJogo.text = $"x{contagem}";
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ReiniciarLevelPelaTela(){
        AudioMng.Instance.PlayAudioClick();
        CanvasLoadingMng.Instance.ExibirPainelLoading();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReiniciarLevelAtual(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VoltarParaMenu(){
        AudioMng.Instance.PlayAudioClick();
        CanvasLoadingMng.Instance.ExibirPainelLoading();
        SceneManager.LoadScene(0);
    }

    public void ProximoLevel(){
        AudioMng.Instance.PlayAudioClick();
        CanvasLoadingMng.Instance.ExibirPainelLoading();
        SceneManager.LoadScene(idLevel+1);
    }    
}