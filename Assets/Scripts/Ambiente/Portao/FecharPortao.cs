using UnityEngine;

public class FecharPortao : MonoBehaviour
{
    private bool fechouPortao = false;
    private Quaternion rotacaoAlvo;
    public float velocidade;
    public GameObject fechadura;
    public GameObject grade;

    void Start()
    {
        rotacaoAlvo = Quaternion.Euler(new Vector3(0,0,0));
    }

    void Update()
    {
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
        AudioMng.Instance.PlayAudioPortao();
    }
    
    private void MudarLayer(){
        transform.gameObject.layer = 6;
    }
}
