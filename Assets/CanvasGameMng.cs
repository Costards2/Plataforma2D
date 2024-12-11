using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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


    // Start is called before the first frame update
    void Start()
    {
        vidas = sptsBarraDeVida.Length -1;
        txtTotalItensColetados.text = $"x{totalItensColetados}";
        txtTempoDeJogo.text = ((int)tempoDoJogo).ToString();
        fimDoTempo = false;
        painelFimDoJogo.SetActive(false);
        idLevel = SceneManager.GetActiveScene().buildIndex;
        qtdItensColetaveis = FindObjectsOfType<ItemColetavel>().Length;
        CanvasLoadingMng.Instance.OcultarPainelLoading();
    }

    // Update is called once per frame
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
        jogadorMorreu = true;//Ter uma variavel que diz que jogador morreu
        vidas = 0;
        imgBarraDeVida.sprite = sptsBarraDeVida[vidas];
        PlayerMng.animacaoPlayer.PlayerDeath();//Ativar a animação de morte
        PlayerMng.Instance.DesabilitarMovimentacao();//Desabilitar a Movimentação do jogador
        PlayerMng.Instance.RemoverSimulacaoDaFisica();//Remover a simulacão da física
        StartCoroutine(ReiniciarLevel());//Contar um tempo para reiniciar a cena
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
        PlayerMng.Instance.CongelarPlayer();//Congelar o player
        SalvarDadosDoLevel();
        StartCoroutine(ExibirTelaFinalDoLevel());//Exibir uma tela final depois de um tempo
    }

    private void SalvarDadosDoLevel(){
        int itensSalvosDoLevel = DBMng.BuscarQtdFrutasLevel(idLevel);
        DefinirMedalhaDoLevel();
        if(totalItensColetados > itensSalvosDoLevel){
            DBMng.SalvarDadosLevel(idLevel,totalItensColetados,idMedalhaLevel);
        }
    }
    private void DefinirMedalhaDoLevel(){
        //Todas as frutas que eu coletei e vou dividir pelo total de frutas na fase
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
        CanvasLoadingMng.Instance.ExibirPainelLoading();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReiniciarLevelAtual(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VoltarParaMenu(){
        CanvasLoadingMng.Instance.ExibirPainelLoading();
        SceneManager.LoadScene(0);
    }

    public void ProximoLevel(){
        CanvasLoadingMng.Instance.ExibirPainelLoading();
        SceneManager.LoadScene(idLevel+1);
    }    
}
