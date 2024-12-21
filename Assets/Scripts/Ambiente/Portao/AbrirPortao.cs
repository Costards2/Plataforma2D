using UnityEngine;

public class AbrirPortao : MonoBehaviour
{
    private bool abriuPortao = false;
    private Quaternion rotacaoAlvo;
    public float velocidade;
    public GameObject fechadura;

    void Start()
    {
        rotacaoAlvo = Quaternion.Euler(new Vector3(0,90,0));
    }

    void Update()
    {
        if(abriuPortao == true){
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
            rotacaoAlvo, velocidade * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D colisor){
        if(colisor.gameObject.tag == "Player" && PlayerMng.Instance.TemChave() == true && 
        abriuPortao == false){
            abriuPortao = true;
            fechadura.SetActive(false);
            AudioMng.Instance.PlayAudioPortao();
            PlayerMng.Instance.DecrementarChave();
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            Destroy(boxCollider);
        }
    }
}
