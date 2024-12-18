using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMng : MonoBehaviour
{
    public static AudioMng Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public AudioSource audioVFX;
    public AudioSource audioMusica;

    public AudioClip clipGame;
    public AudioClip clipMenu;
    public AudioClip clipClick;
    public AudioClip clipFruta;
    public AudioClip[] clipsDanos;
    public AudioClip clipPular;
    public AudioClip clipCorrer;
    public AudioClip clipChave;
    public AudioClip clipChefe;
    public AudioClip clipSurgir;
    public AudioClip clipProjetil;
    public AudioClip clipDanoInimigo;
    public AudioClip clipItemFinal;
    public AudioClip clipMortePlayer;
    public AudioClip clipPortao;
    public AudioClip clipMorteChefe;


    public void MudarVolume(Volume volume){
        audioVFX.volume = volume.vfx;
        audioMusica.volume = volume.musica;
    }

    public void PlayAudioMenu(){
        if(audioMusica.clip != clipMenu){
            audioMusica.Stop();
            audioMusica.clip = clipMenu;
            audioMusica.Play();
        }
    }

    public void PlayAudioGame(){
        if(audioMusica.clip != clipGame){
            audioMusica.Stop();
            audioMusica.clip = clipGame;
            audioMusica.Play();
        }
    }

    public void PlayAudioClick(){
        audioVFX.PlayOneShot(clipClick);
    }

    public void PlayAudioFruta(){
        audioVFX.PlayOneShot(clipFruta);
    }

    public void PlayAudioDanos(){
        var audioSorteado = new System.Random().Next(0, clipsDanos.Length);
        audioVFX.PlayOneShot(clipsDanos[audioSorteado]);
    }

    public void PlayAudioPular(){
        audioVFX.PlayOneShot(clipPular);
    }

    public void PlayAudioCorrer(){
        audioVFX.PlayOneShot(clipCorrer);
    }

    public void PlayAudioChave(){
        audioVFX.PlayOneShot(clipChave);
    }

    public void PlayAudioChefe(){
        audioVFX.PlayOneShot(clipChefe);
    }

    public void PlayAudioSurgir(){
        audioVFX.PlayOneShot(clipSurgir);
    }

    public void PlayAudioProjetil(){
        audioVFX.PlayOneShot(clipProjetil);
    }

    public void PlayAudioDanoInimigo(){
        audioVFX.PlayOneShot(clipDanoInimigo);
    }

    public void PlayAudioItemFinal(){
        audioVFX.PlayOneShot(clipItemFinal);
    }

    public void PlayAudioMorte(){
        audioVFX.PlayOneShot(clipMortePlayer);
    }

    public void PlayAudioPortao(){
        audioVFX.PlayOneShot(clipPortao);
    }

    public void PlayAudioMorteChefe(){
        audioVFX.PlayOneShot(clipMorteChefe);
    }
}
