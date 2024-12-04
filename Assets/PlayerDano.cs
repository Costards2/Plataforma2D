using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDano : MonoBehaviour
{
    public void DanoAoPlayer(){
        //Sortear a direção para expelir o jogador
        System.Random random = new System.Random();
        int valorSorteado = random.Next(0,2);
        int direcaoX = valorSorteado == 0 ? -1000 : 1000;
        PlayerMng.animacaoPlayer.PlayDamagePlayer();
        PlayerMng.Instance.ResetarVelocidadeDaFisica();//Resetar a velocidade da fisica
        PlayerMng.Instance.ArremessarPlayer(direcaoX,1000);//Arremessar o Player para uma direção

        CanvasGameMng.Instance.DecrementarVidaJogador();//Decrementar a vida do player
    }
}
