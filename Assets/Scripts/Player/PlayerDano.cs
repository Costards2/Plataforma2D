using UnityEngine;

public class PlayerDano : MonoBehaviour
{
    public void DanoAoPlayer(){
        if(CanvasGameMng.Instance.fimDoTempo == true) return;

        System.Random random = new System.Random();
        int valorSorteado = random.Next(0,2);
        int direcaoX = valorSorteado == 0 ? -1000 : 1000;
        PlayerMng.animacaoPlayer.PlayDamagePlayer();
        AudioMng.Instance.PlayAudioDanos();
        PlayerMng.Instance.ResetarVelocidadeDaFisica();
        PlayerMng.Instance.ArremessarPlayer(direcaoX,1000);

        CanvasGameMng.Instance.DecrementarVidaJogador();
    }
}
