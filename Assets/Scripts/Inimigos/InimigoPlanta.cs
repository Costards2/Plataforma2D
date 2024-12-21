using UnityEngine;

public class InimigoPlanta : MonoBehaviour
{
    private SpriteRenderer corpo;
    private Animator animator;
    public float tempoDeEspera = 3f;
    private float tempoAgora;
    public GameObject projetil;
    private bool teveDano = false;

    void Start()
    {
        corpo = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        tempoAgora = Time.time + tempoDeEspera;
    }

    void Update()
    {
        if(teveDano == true) return;

        if(Time.time > tempoAgora){
            tempoAgora = Time.time + tempoDeEspera;
            animator.SetTrigger("fire");
        }
    }

    public void AtirarProjetil(){
        GameObject projetilCriado = Instantiate(projetil);
        AudioMng.Instance.PlayAudioProjetil();

        if(corpo.flipX == true){
            projetilCriado.transform.position = new Vector3(transform.position.x + 0.5f,
            transform.position.y + 0.14f,0);
            projetilCriado.GetComponent<ProjetilPlanta>().MudarDirecao(Vector3.right);
        }
        else{
            projetilCriado.transform.position = new Vector3(transform.position.x - 0.5f,
            transform.position.y + 0.14f,0);
            projetilCriado.GetComponent<ProjetilPlanta>().MudarDirecao(Vector3.left);
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && teveDano == false){
            PlayerMng.playerDano.DanoAoPlayer();
            AudioMng.Instance.PlayAudioDanoInimigo();
            teveDano = true;
            animator.SetTrigger("hit");
        }
    }

    public void DestruirPlanta(){
        Destroy(gameObject);
    }
}