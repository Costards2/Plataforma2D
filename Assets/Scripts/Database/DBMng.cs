using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBMng
{
    //Caminhos de onde será salvo os dados
    private const string LEVEL_DATA = "level-data-";//Dado do level, qtd frutas que eu coletei
    private const string HABILITA_LEVEL = "habilita-level-";//Se o level está habilitado
    private const string MEDALHA_LEVEL = "medalha-level-";//Salvar a medalha conquistada na fase
    private const string VOLUME = "volume";//Armazenar os dados dos volumes do jogo

    //Método para salvar os dados do level
    public static void SalvarDadosLevel(int idLevel, int qtdFrutas, int idMedalha){
        PlayerPrefs.SetInt(LEVEL_DATA+idLevel,qtdFrutas); //Salva as frutas do level na memória
        PlayerPrefs.SetInt(HABILITA_LEVEL + (idLevel+1),1); //Salva a informação de liberação do próximo level
        PlayerPrefs.SetInt(MEDALHA_LEVEL + idLevel, idMedalha);
    }

    //Método para buscar a quantidade de frutas do level
    public static int BuscarQtdFrutasLevel(int idLevel){
        return PlayerPrefs.GetInt(LEVEL_DATA+idLevel);
    }

    //Método para ver se o level esta habilitado
    public static int BuscarLevelHabilitado(int idLevel){
        return PlayerPrefs.GetInt(HABILITA_LEVEL + idLevel);
    }

    //Método para buscar a medalha do level
    public static int BuscarMedalhaLevel(int idLevel){
        return PlayerPrefs.GetInt(MEDALHA_LEVEL+idLevel);
    }

    //Salvar volumes
    //Obter volumes
}
