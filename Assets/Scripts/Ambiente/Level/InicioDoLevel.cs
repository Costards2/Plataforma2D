using UnityEngine;

public class InicioDoLevel : MonoBehaviour
{
    public GameObject posicaoPlayer;

    void Start()
    {
        PlayerMng.Instance.gameObject.transform.position = posicaoPlayer.transform.position;
        AudioMng.Instance.PlayAudioSurgir();
    }
}
