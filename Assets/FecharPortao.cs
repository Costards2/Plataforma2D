using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FecharPortao : MonoBehaviour
{
    private bool fechouPortao = false;
    private Quaternion rotacaoAlvo;
    public float velocidade;
    public GameObject fechadura;
    public GameObject grade;
    // Start is called before the first frame update
    void Start()
    {
        rotacaoAlvo = Quaternion.Euler(new Vector3(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se posso fechar o portao
        if(fechouPortao == true){
            grade.transform.rotation = Quaternion.RotateTowards(
                grade.transform.rotation,
                rotacaoAlvo,
                velocidade * Time.deltaTime
            );
        }
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && fechouPortao == false){
            fechouPortao = true;
            GetComponent<BoxCollider2D>().isTrigger = false;
            Invoke("AtivarFechadura",1f);
            Invoke("MudarLayer",1f);
        }
    }

    private void AtivarFechadura(){
        fechadura.SetActive(true);
    }
    private void MudarLayer(){
        transform.gameObject.layer = 6;
    }
}
