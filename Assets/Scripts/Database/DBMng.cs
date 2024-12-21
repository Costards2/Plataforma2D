using UnityEngine;

public static class DBMng
{
    private const string LEVEL_DATA = "level-data-";
    private const string HABILITA_LEVEL = "habilita-level-";
    private const string MEDALHA_LEVEL = "medalha-level-";
    private const string VOLUME = "volume";

    public static void SalvarDadosLevel(int idLevel, int qtdFrutas, int idMedalha){
        PlayerPrefs.SetInt(LEVEL_DATA+idLevel,qtdFrutas);
        PlayerPrefs.SetInt(HABILITA_LEVEL + (idLevel+1),1);
        PlayerPrefs.SetInt(MEDALHA_LEVEL + idLevel, idMedalha);
    }

    public static int BuscarQtdFrutasLevel(int idLevel){
        return PlayerPrefs.GetInt(LEVEL_DATA+idLevel);
    }

    public static int BuscarLevelHabilitado(int idLevel){
        return PlayerPrefs.GetInt(HABILITA_LEVEL + idLevel);
    }

    public static int BuscarMedalhaLevel(int idLevel){
        return PlayerPrefs.GetInt(MEDALHA_LEVEL+idLevel);
    }

    public static void SalvarVolume(float volumeVFX, float volumeMusica){
        Volume volume = new Volume();
        volume.vfx = volumeVFX;
        volume.musica = volumeMusica;
        var json = JsonUtility.ToJson(volume);
        Debug.Log(json);
        PlayerPrefs.SetString(VOLUME,json);
    }
    
    public static Volume ObterVolumes(){
        var json = PlayerPrefs.GetString(VOLUME);
        Volume volume = JsonUtility.FromJson<Volume>(json);
        if(volume == null){
            SalvarVolume(1,1);
            json = PlayerPrefs.GetString(VOLUME);
            volume = JsonUtility.FromJson<Volume>(json);
        }
        return volume;
    }
}