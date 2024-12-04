using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCorpoPlayer : MonoBehaviour
{
    private SpriteRenderer spriteCorpo;

    public bool VisaoEsquerdaOuDireita {
        get {return spriteCorpo.flipX;}
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteCorpo = GetComponent<SpriteRenderer>();
    }

    public void OlharDireita(){
        spriteCorpo.flipX = false;
    }

    public void OlharEsquerda(){
        spriteCorpo.flipX = true;
    }
}
