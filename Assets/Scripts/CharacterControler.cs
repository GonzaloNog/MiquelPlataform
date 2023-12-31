using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [Header("Player Skills")]
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 5f;
    private float speed;
    private bool shiftJump = false;
    private float finalJump = 5f;
    public float upwardForceOnKill = 2f; 


    [Header("Layer")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Physics")]
    private Rigidbody2D rb;
    private bool isGrounded;

    float dirX;
    Animator anim;
    bool isDead;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!LevelManager.instance.getGameOver())
        {
            if (!isDead)
            {
                isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

                float horizontalInput = Input.GetAxis("Horizontal");

                Vector2 movement = new Vector2(horizontalInput, 0).normalized;
                if (isGrounded)
                    speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
                rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

                if (isGrounded && Input.GetKeyDown(KeyCode.Space))
                {
                    shiftJump = Input.GetKey(KeyCode.LeftShift) ? true : false;
                    if (shiftJump)
                        finalJump = jumpForce * 1.2f;
                    else
                        finalJump = jumpForce;
                    rb.AddForce(new Vector2(0, finalJump), ForceMode2D.Impulse);
                    LevelManager.instance.am.newSFX("jump");
                }

                SetAnimationState();

                dirX = Input.GetAxisRaw("Horizontal") * speed;

                if (dirX < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (dirX > 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
        }
        
    }

    void SetAnimationState()
    {
        // Verificar si ya ha muerto y la animación de muerte no ha comenzado
        if (isDead)
        {
            // Realizar acciones de muerte (reproducir animación, mostrar mensaje, etc.)
            anim.SetBool("isDead", true);
            rb.velocity = Vector2.zero;  // Detener el movimiento al morir
            rb.gravityScale = 0;  // Desactivar la gravedad al morir
            return; 
        }

        // Resto de la lógica de animación
        anim.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(dirX) > 0);
        anim.SetBool("isWalking", !anim.GetBool("isRunning") && Mathf.Abs(dirX) > 0);
        anim.SetBool("isJumping", !isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!LevelManager.instance.getGameOver())
        {
            if (collision.gameObject.CompareTag("enemy"))
            {

                // Aplica una pequeña fuerza hacia arriba a SuperGirl al matar al orco
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0f); // Detén la velocidad vertical actual
                    rb.AddForce(new Vector2(0f, upwardForceOnKill), ForceMode2D.Impulse);
                }
            }
        }
    }


    public void CharacterDead()
    {
        LevelManager.instance.am.newSFX("dead");
        isDead = true;
        anim.SetBool("isDead", true);
        LevelManager.instance.setGameOver(true);
    }
    
    public bool getIsDead()
    {
        return isDead;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BoxDead")
        {
            CharacterDead();
            LevelManager.instance.setGameOver(true);
        }
        if(collision.tag == "levelFinish")
        {
            Debug.Log("levelFinish");
            if (LevelManager.instance.getWin())
            {
                LevelManager.instance.ui.WinUI();
            }
        }
    }
}
