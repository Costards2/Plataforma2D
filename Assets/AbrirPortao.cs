using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPortao : MonoBehaviour
{
    private bool abriuPortao = false;
    private Quaternion rotacaoAlvo;
    public float velocidade;
    public GameObject fechadura;
    // Start is called before the first frame update
    void Start()
    {
        rotacaoAlvo = Quaternion.Euler(new Vector3(0,90,0));
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentação de rotação do portão

        //Verificar se pode abrir o portao
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
            PlayerMng.Instance.DecrementarChave();
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            Destroy(boxCollider);
        }
    }
}
