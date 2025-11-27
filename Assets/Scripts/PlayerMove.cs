using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2.0f;
    public float jumpSpeed = 3.0f;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump = false;
    Rigidbody2D rb2D; // Referencia al componente
    public bool betterJump = false; // activar/desactivar el salto mejorado
    public float fallMultiplier = 0.5f; // tiempo de caida bajo
    public float lowJumpMultiplier = 1f; // tiempo de caida alto

    // Se hace public, para poder arrastrarlo desde el editor
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Para saltar
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true; // Resetea el doble salto al estar en el suelo
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false; // Se gasta el doble salto

                    }
                }
            }
        }

        //***Para controlar la animación de salto 
        // Cuando no estamos en el suelo
        if (CheckGround.isGrounded == false)
        {
            //Estamos saltando
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded)
        {
            //Estamos en el suelo
            animator.SetBool("Jump", false);
        }
        //**
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            // Para moverse a la derecha
            //(x,y)
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            //Para moverse a la izquierda
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }



        // Para detectar el tipo de salto
        if (betterJump)
        {
            //  
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime; //x,y(0,1)
            }
            //
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime; //x,y(0,1)

            }
        }
    }
}
