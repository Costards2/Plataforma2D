using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && CanvasGameMng.Instance.jogadorMorreu == false)
        {
            CanvasGameMng.Instance.MatarJogador();
        }
    }
}
