using UnityEngine;

public class MovimentarChefe : MonoBehaviour
{
    private ChefeMng chefeMng;
    private SpriteRenderer corpo;
    public float velocidade;

    void Start()
    {
        chefeMng = GetComponent<ChefeMng>();
        corpo = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(chefeMng.estaMovendo == false) return;

        if(corpo.flipX == false){
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }
        else{
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }
    }

    public void FlipCorpo(){
        corpo.flipX = !corpo.flipX;
    }
}