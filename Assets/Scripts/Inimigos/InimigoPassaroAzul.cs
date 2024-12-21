using UnityEngine;

public class InimigoPassaroAzul : MonoBehaviour
{
    private SpriteRenderer sptCorpo;
    public float distanciaDeMovimento;
    public float velocidade;
    private Vector3 posicaoInicial;
    private Vector3 posicaoFinal;
    private Vector3 posicaoAlvo;
    private bool estaMorto = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        sptCorpo = GetComponent<SpriteRenderer>();
        posicaoInicial = transform.position;
        posicaoFinal = transform.position + new Vector3(distanciaDeMovimento,0,0);
        posicaoAlvo = posicaoFinal;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            posicaoAlvo,
            velocidade * Time.deltaTime);

        if(Vector3.Distance(transform.position, posicaoAlvo)<0.001f){
            if(sptCorpo.flipX == false){
                posicaoAlvo = posicaoInicial;
            }
            else{
                posicaoAlvo = posicaoFinal;
            }
            sptCorpo.flipX = !sptCorpo.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "PePlayer" && estaMorto == false){
            PlayerMng.Instance.ExpelirPlayer();
            AudioMng.Instance.PlayAudioDanoInimigo();
            animator.SetTrigger("morte");
            estaMorto = true;
        }
    }

    public void DestruirInimigo(){
        Destroy(gameObject);
    }
}