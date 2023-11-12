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

    [Header("Phyisics")]
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput, 0).normalized;

        moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 10f : 5f;
        rb.velocity = new Vector2(movement.x * moveSpeed,rb.velocity.y);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        SetAnimationState();

        if (!isDead)
        {
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
        anim.SetBool("isRunning", Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(dirX) > 0);
        anim.SetBool("isWalking", !anim.GetBool("isRunning") && Mathf.Abs(dirX) > 0);
        anim.SetBool("isJumping", !isGrounded);

    }
}
