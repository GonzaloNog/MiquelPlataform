using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [Header("Player Skills")]
    public float moveSpeed = 1f;
    public float jumpForce = 5f;

    [Header("Layer")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Physics")]
    private Rigidbody2D rb;
    private bool isGrounded;

    float dirX;
    Animator anim;
    bool isDead;
    bool hasDied;  // Nueva variable para controlar si ya ha muerto
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

            float horizontalInput = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(horizontalInput, 0).normalized;

            moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 10f : 5f;
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("jump");
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

            SetAnimationState();

            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

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

    void SetAnimationState()
    {
        // Verificar si ya ha muerto y la animación de muerte no ha comenzado
        if (isDead && !hasDied)
        {
            // Realizar acciones de muerte (reproducir animación, mostrar mensaje, etc.)
            anim.SetBool("isDead", true);
            hasDied = true;  // Marcar que la animación de muerte ya ha comenzado
            rb.velocity = Vector2.zero;  // Detener el movimiento al morir
            rb.gravityScale = 0;  // Desactivar la gravedad al morir
            return;  // Salir de la función para evitar que se ejecute el resto de la lógica
        }

        // Resto de la lógica de animación
        anim.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(dirX) > 0);
        anim.SetBool("isWalking", !anim.GetBool("isRunning") && Mathf.Abs(dirX) > 0);
        anim.SetBool("isJumping", !isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !isDead)
        {
            // SuperGirl choca con el Ogro, activa la muerte
            isDead = true;
            anim.SetBool("isDead", true);
        }
    }
}
