using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadX = 0; //Horizontal para movimiento horizontal 
    public float velocidadY = 0; //Vertical

 


    //Rigibody 2D

    Rigidbody2D rb;

    //Animator
    private Animator animator;

    //Renderer
    private SpriteRenderer rendererPersonaje;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rendererPersonaje = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //Caminar
        float movHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movHorizontal * velocidadX, rb.velocity.y);

        //Saltar
        float movVertical = Input.GetAxis("Vertical");
        if (movVertical > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, movVertical * velocidadY);
        }
        float velocidad = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("velocidad", velocidad);

        //Direccion adecuada

        rendererPersonaje.flipX = rb.velocity.x < 0;
        //Parametro para animacion de saltar 
        animator.SetBool("saltando", PruebaPiso.estaEnPiso); //???????
    }
}