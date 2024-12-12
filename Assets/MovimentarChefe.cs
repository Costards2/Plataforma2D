using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarChefe : MonoBehaviour
{
    private ChefeMng chefeMng;
    private SpriteRenderer spriteRenderer;
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        chefeMng = GetComponent<ChefeMng>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chefeMng.estaMovendo == false) return;

        if(spriteRenderer.flipX == false)
        {
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }
    }

    public void FlipSprite()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
